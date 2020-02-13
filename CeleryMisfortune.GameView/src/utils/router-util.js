/**
 * ①添
 * @@新增 定义初始化菜单
 */

import Util from '@/lib/util'
import Main from '@/components/game/main' // Main 是架构组件，不在后台返回，在文件里单独引入
import { GetRouterJson } from '@/api/app'
// 初始化路由
export const initRouter = () => {
  GetRouterJson().then(res => {
    localStorage.setItem('routerStorage', JSON.stringify(res.data))
  })
}
// 过滤菜单不显示项
export const filterMenu = (menus) => {
  const filterMenus = menus.filter(route => {
    route.meta.title = route.title
    if (route.children && route.children.length) {
      route.children = filterMenu(route.children)
    }
    // 权限验证--todo
    return !route.meta.hideInMenu
  })
  return filterMenus
}
// 加载路由菜单,从localStorage拿到路由,在创建路由时使用
export const dynamicRouterAdd = () => {
  let dynamicRouter = []
  let data = JSON.parse(localStorage.getItem('routerStorage'))
  if (!data || data === 'undefined' || data === null || data === '[]') {
    return dynamicRouter
  }
  dynamicRouter = filterAsyncRouter(data)
  return dynamicRouter
}

// @函数: 遍历后台传来的路由字符串，转换为组件对象
export const filterAsyncRouter = (asyncRouterMap) => {
  const accessedRouters = asyncRouterMap.filter(route => {
    route.meta.title = route.title
    if (route.component) {
      if (route.component === 'Main' || route.component.name === 'Main') { // Main组件特殊处理
        route.component = Main
      } else {
        route.component = lazyLoadingCop(route.component)
      }
    } else {
      route.component = lazyLoadingCop(route.path)
    }
    if (route.children && route.children.length) {
      route.children = filterAsyncRouter(route.children)
    }
    return true
  })
  return accessedRouters
}

//  @函数: 引入组件
export const lazyLoadingCop = file => require('@/pages/' + file + '.vue').default

/**
 * @param {Array} list 通过路由列表得到菜单列表
 * @returns {Array}
 */
export const getMenuByRouter = (list, access) => {
  let res = []
  list.forEach(item => {
    if (!item.meta || (item.meta && !item.meta.hideInMenu)) {
      let obj = {
        icon: (item.meta && item.meta.icon) || '',
        name: item.name,
        query: item.query,
        meta: item.meta
      }
      if ((hasChild(item) || (item.meta && item.meta.showAlways)) && showThisMenuEle(item, access)) {
        obj.children = getMenuByRouter(item.children, access)
      }
      if (item.meta && item.meta.href) obj.href = item.meta.href
      if (showThisMenuEle(item, access)) res.push(obj)
    }
  })
  return res
}

export const hasChild = (item) => {
  return item.children && item.children.length !== 0
}

const showThisMenuEle = (item, access) => {
  if (item.meta && item.meta.access) {
    if (Util.hasOneOf([item.meta.access], access)) return true
    else return false
  } else return true
}

// 获取树节点
export const GetTreeNode = (nodes, key) => {
  var data = nodes.filter(node => {
    if (node.name === key) {
      return node
    }
    if (node.children && node.children.length) {
      GetTreeNode(node.children, key)
    }
  })
  return data
}
// 更新树节点
export const UpdateTreeNode = (nodes, curNode) => {
  nodes = nodes.forEach(node => {
    if (node.name === curNode.name) {
      node = curNode
    }
    if (node.children && node.children.length) {
      UpdateTreeNode(node.children, curNode)
    }
  })
  return nodes
}
