import url from './url'
import config from '../config'
const AppConsts = {
  useAbp: config.useAbp,
  userManagement: {
    defaultAdminUserName: 'admin'
  },
  localization: {
    defaultLocalizationSourceName: 'Kadmin'
  },
  authorization: {
    encrptedAuthTokenName: 'enc_auth_token'
  },
  appBaseUrl: 'http://localhost:8080',
  remoteServiceBaseUrl: url
}
export default AppConsts
