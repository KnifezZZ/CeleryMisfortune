import ajax from '@/lib/ajax'
// import qs from 'qs'

export const CreatedOrUpdate = (payload) => {
  return ajax.post('/api/services/app/PlayerInfo/CreateOrUpdate', { user: payload })
}

export const GetForEdit = (id) => {
  return ajax.get('/api/services/app/PlayerInfo/GetForEdit?id=' + id)
}

export const Delete = (id) => {
  return ajax.delete('/api/services/app/PlayerInfo/Delete?id=' + id)
}

export const Search = (payload) => {
  return ajax.post('/api/PlayerInfo/Search', payload)
}
export const GetPlayerSpecialInfo = (payload) => {
  return ajax.post('/api/PlayerSpecial/Search', payload)
}
export const GetPlayerInfoById = (id) => {
  return ajax.get('/api/PlayerInfo/' + id)
}
export const GetPlayerUnitInfoById = (id) => {
  return ajax.get('/api/PlayerInfo/GetUnitInfo/' + id)
}
