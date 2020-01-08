
import { dynamicRouterAdd, getMenuByRouter } from '@/utils/router-util'
export default {
  state: {
    menus: []
  },
  getters: {
    menus: (state, getters, rootState) => getMenuByRouter(dynamicRouterAdd(), rootState.user.access)
  }
}
