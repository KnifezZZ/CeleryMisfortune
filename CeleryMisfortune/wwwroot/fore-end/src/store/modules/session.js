import ajax from '@/lib/ajax'
import util from '@/lib/util'
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
