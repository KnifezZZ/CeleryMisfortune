import { AccountLogin } from '@/api/user'
import Util from '@/lib/util'
import appconst from '@/lib/appconst'
import { initRouter } from '@/utils/router-util'
export default {
  state: {
    userAccount: '',
    playerlist: null,
    access: []
  },
  mutations: {
    setUserId (state, userId) {
      state.userId = userId
    },
    setUserAccount (state, userAccount) {
      state.userAccount = userAccount
    }
  },
  actions: {
    // 登录
    handleLogin ({ state, commit }, values) {
      return new Promise((resolve, reject) => {
        values.userName = values.userName.trim()
        commit('setUserAccount', values.userName)
        var payload = {
          userid: values.userName,
          password: values.password,
          rememberLogin: values.remember,
          cookie: false
        }
        AccountLogin(payload).then(res => {
          const data = res.data
          if (res.status === 200) {
            debugger
            var tokenExpireDate = payload.rememberMe ? (new Date(new Date().getTime() + 1000 * data.expires_in)) : undefined
            Util.abp.auth.setToken(data.access_token, tokenExpireDate)
            Util.abp.utils.setCookieValue(appconst.authorization.encrptedAuthTokenName, data.refresh_token, tokenExpireDate, Util.abp.appPath)
            // 获取菜单路由
            initRouter()
          }
          // if (this.$config.useAbp) {
          //   const data = res.data.result // abp
          //   if (res.data.success) {
          //     var tokenExpireDate = payload.rememberMe ? (new Date(new Date().getTime() + 1000 * data.expireInSeconds)) : undefined
          //     Util.abp.auth.setToken(data.accessToken, tokenExpireDate)
          //     Util.abp.utils.setCookieValue(appconst.authorization.encrptedAuthTokenName, data.encryptedAccessToken, tokenExpireDate, Util.abp.appPath)
          //   }
          // }
          resolve(res.data)
        }).catch(err => {
          reject(err)
        })
      })
    },
    // 退出登录
    handleLogOut ({ state, commit }) {
      return new Promise((resolve, reject) => {
        // 如果你的退出登录无需请求接口，则可以直接使用下面三行代码而无需使用logout调用接口
        commit('setToken', '')
        // 退出登录清除所有缓存
        localStorage.clear()
        resolve()
      })
    }
  }

}
