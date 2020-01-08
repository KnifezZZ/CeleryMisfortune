import Vue from 'vue'
import Router from 'vue-router'
import routes from './routers'
import Utils from '@/lib/util'
import { initRouter } from '@/utils/router-util'
import config from '@/config'
Vue.use(Router)

const router = new Router({
  routes,
  mode: 'hash'
})

const LOGIN_PAGE_NAME = 'login'

const turnTo = (to, access, next) => {
  if (Utils.canTurnTo(to.name, access, routes) || !config.useRole) next() // 有权限，可访问
  else next({ replace: true, name: 'error_401' }) // 无权限，重定向到401页面
}

router.beforeEach((to, from, next) => {
  if (!config.useLogin) {
    initRouter()
    next()
  } else {
    const token = Utils.abp.auth.getToken()
    if (!token && to.name !== LOGIN_PAGE_NAME) {
      // 未登录且要跳转的页面不是登录页
      next({
        name: LOGIN_PAGE_NAME // 跳转到登录页
      })
    } else if (!token && to.name === LOGIN_PAGE_NAME) {
      // 未登陆且要跳转的页面是登录页
      next() // 跳转
    } else if (token && to.name === LOGIN_PAGE_NAME) {
      // 已登录且要跳转的页面是登录页
      next({
        name: config.homePage
      })
    } else {
      turnTo(to, [], next)
    }
  }
})

router.afterEach(to => {
  Utils.title(to.meta.title)
  window.scrollTo(0, 0)
})
export default router
