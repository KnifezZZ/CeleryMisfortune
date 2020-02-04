import ajax from '@/lib/ajax'
import util from '@/lib/util'
import appconst from '@/lib/appconst'
const state = {
  application: null,
  user: null,
  tenant: null
}
const mutations = {
}
const actions = {
  async init (content) {
    let rep = await ajax.get('/api/services/app/Session/GetCurrentLoginInformations', {
      headers: {
        'Abp.TenantId': util.abp.multiTenancy.getTenantIdCookie()
      }
    })
    content.state.application = rep.data.result.application
    content.state.user = rep.data.result.user
    content.state.tenant = rep.data.result.tenant
  },
  async refreshToken (content) {
    debugger
    ajax.post('/api/_Account/RefreshToken', { refreshToken: window.abp.auth.getToken() }).then(res => {
      window.abp.auth.setToken(res.refresh_token, res.tokenExpireDate * 2)
      window.abp.utils.setCookieValue(appconst.authorization.encrptedAuthTokenName, res.accessToken, res.tokenExpireDate)
    })
  }
}
const getters = {}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
