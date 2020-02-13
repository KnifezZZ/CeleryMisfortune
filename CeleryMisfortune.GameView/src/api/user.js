import ajax from '@/lib/ajax'
import qs from 'qs'
export const GetPaged = (pageIndex, pageSize) => {
  return ajax.get('/api/services/app/User/GetAll?SkipCount=' + (pageIndex - 1) * pageSize + '&MaxResultCount=' + pageSize)
}

export const CreatedOrUpdate = (payload) => {
  return ajax.post('/api/services/app/User/CreateOrUpdate', { user: payload })
}

export const GetForEdit = (id) => {
  return ajax.get('/api/services/app/User/GetForEdit?id=' + id)
}

export const Delete = (id) => {
  return ajax.delete('/api/services/app/User/Delete?id=' + id)
}

export const AccountLogin = (payload) => {
  return ajax.post('/api/_Account/Login', qs.stringify(payload), { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
}
