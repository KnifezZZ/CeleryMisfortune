
import { dynamicRouterAdd } from '@/utils/router-util'
// import Main from '@/components/admin/main' // ①添 引入加载菜单
// 作为Main组件的子页面展示并且在左侧菜单显示的路由写在appRouter里
export const otherRouter = [{
  path: '/login',
  name: 'login',
  meta: {
    title: 'Login - 登录',
    hideInMenu: true
  },
  component: () => import('@/pages/login/login.vue')
}, {
  path: '/401',
  name: 'error_401',
  meta: {
    hideInMenu: true
  },
  component: () => import('@/pages/error-page/401.vue')
}, {
  path: '/500',
  meta: {
    hideInMenu: true,
    title: '500-服务端错误'
  },
  name: 'error_500',
  component: () => import('@/pages/error-page/500.vue')
}
]
export const appRouter = [...dynamicRouterAdd()]

export const routes = [
  ...otherRouter,
  ...appRouter,
  {
    path: '*',
    name: 'error_404',
    meta: {
      hideInMenu: true,
      title: '404-页面找不到了'
    },
    component: () => import('@/pages/error-page/404.vue')
  }
]
export default routes
