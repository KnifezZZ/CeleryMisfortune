import axios from 'axios'
import appconst from './appconst'
import store from '@/store'
import Vue from 'vue'
const ajax = axios.create({
  baseURL: appconst.remoteServiceBaseUrl,
  timeout: 30000
})
ajax.interceptors.request.use(function (config) {
  if (appconst.useAbp) {
    config.headers.common['.AspNetCore.Culture'] = window.abp.utils.getCookieValue('Abp.Localization.CultureName')
    config.headers.common['Abp.TenantId'] = window.abp.multiTenancy.getTenantIdCookie()
  }
  if (window.abp.auth.getToken()) {
    if (config.url !== '/api/_Account/RefreshToken' && !window.abp.utils.getCookieValue(appconst.authorization.encrptedAuthTokenName)) {
      // 刷新token功能
      store.dispatch('session/refreshToken')
    }
    config.headers.common['Authorization'] = 'Bearer ' + window.abp.utils.getCookieValue(appconst.authorization.encrptedAuthTokenName)
  }
  return config
}, function (error) {
  return Promise.reject(error)
})
let vm = new Vue({})
ajax.interceptors.response.use((respon) => {
  return respon
}, (error) => {
  if (!!error.response && !!error.message) {
    vm.$error({
      title: '[CODE: ' + error.response.status + ']' + error.response.data,
      content: error.message
    })
  } else {
    vm.$error({
      title: '未知错误!' + error.message
    })
  }

  // Abp
  // if (!!error.response && !!error.response.data.error && !!error.response.data.error.message && error.response.data.error.details) {
  //   vm.$error({
  //     title: error.response.data.error.message,
  //     content: error.response.data.error.details
  //   })
  // } else if (!!error.response && !!error.response.data.error && !!error.response.data.error.message) {
  //   vm.$error({
  //     title: window.abp.localization.localize('LoginFailed'),
  //     content: error.response.data.error.message
  //   })
  // } else if (!error.response) {
  //   vm.$error({
  //     title: '未知错误!' + error.message
  //   })
  // }
  return Promise.reject(error)
})
export default ajax
