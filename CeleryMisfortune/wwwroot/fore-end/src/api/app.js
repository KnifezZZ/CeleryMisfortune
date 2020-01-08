import ajax from '@/lib/ajax'

export const GetRouterJson = () => {
  return ajax.get(window.location.origin + '/static/route/router.json')
}
export const GetMockJson = (fileName) => {
  return ajax.get(window.location.origin + '/static/mocks/' + fileName + '.json')
}

export const AuthLogin = (payload) => {
  return ajax.post('/api/TokenAuth/Authenticate', payload)
}

export const GetMenuList = (payload) => {
  return ajax.post('/api/TokenAuth/Authenticate', payload)
}
