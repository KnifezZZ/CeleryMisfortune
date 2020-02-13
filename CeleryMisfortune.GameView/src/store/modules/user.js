import { AccountLogin } from '@/api/user'
import Util from '@/lib/util'
import appconst from '@/lib/appconst'
import { initRouter } from '@/utils/router-util'
import SignalRAspNetCoreHelper from '@/lib/SignalRAspNetCoreHelper'
export default {
  state: {
    userAccount: '',
    currUser: '',
    access: []
  },
  mutations: {
    setUserId (state, userId) {
      state.currUser = userId
    },
    setUserAccount (state, userAccount) {
      state.userAccount = userAccount
    },
    setToken (state, token) {
      Util.abp.auth.setToken(token.refresh_token, token.tokenExpireDate * 2)
      Util.abp.utils.setCookieValue(appconst.authorization.encrptedAuthTokenName, token.access_token, token.tokenExpireDate)
    }
  },
  actions: {
    // 登录
    handleLogin ({ state, commit }, values) {
      return new Promise((resolve, reject) => {
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
            // 绑定token
            commit('setToken', {
              access_token: data.access_token,
              refresh_token: data.refresh_token,
              tokenExpireDate: tokenExpireDate
            })
            // 绑定用户名
            commit('setUserAccount', values.userName.trim())
            // 链接signalR服务器
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
        commit('setToken', {
          access_token: '',
          refresh_token: '',
          tokenExpireDate: 0
        })
        // 退出登录清除所有缓存
        localStorage.clear()
        resolve()
      })
    }
  }

}
