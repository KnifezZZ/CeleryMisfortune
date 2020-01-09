import { AccountLogin } from '@/api/user'
import Util from '@/lib/util'
import appconst from '@/lib/appconst'
import { initRouter } from '@/utils/router-util'
import SignalRAspNetCoreHelper from '@/lib/SignalRAspNetCoreHelper'
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
            var tokenExpireDate = payload.rememberMe ? (new Date(new Date().getTime() + 1000 * data.expires_in)) : undefined
            Util.abp.auth.setToken(data.refresh_token, tokenExpireDate)
            Util.abp.utils.setCookieValue(appconst.authorization.encrptedAuthTokenName, data.access_token, tokenExpireDate, Util.abp.appPath)
            SignalRAspNetCoreHelper.initSignalR()
            // 获取菜单路由
            initRouter()
          }
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
