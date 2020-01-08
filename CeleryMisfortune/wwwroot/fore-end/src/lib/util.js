import appconst from './appconst'
class Util {
  abp = window.abp;
  loadScript (url) {
    var script = document.createElement('script')
    script.type = 'text/javascript'
    script.src = url
    document.body.appendChild(script)
  }
  title (title) {
    window.document.title = title + '--' + appconst.localization.defaultLocalizationSourceName
    // let appname = this.abp.localization.localize('AppName', appconst.localization.defaultLocalizationSourceName)
    // let page = this.abp.localization.localize(title, appconst.localization.defaultLocalizationSourceName)
    // window.document.title = appname + '--' + page
  }
  inOf (arr, targetArr) {
    let res = true
    arr.forEach(item => {
      if (targetArr.indexOf(item) < 0) {
        res = false
      }
    })
    return res
  }
  oneOf (ele, targetArr) {
    if (targetArr.indexOf(ele) >= 0) {
      return true
    } else {
      return false
    }
  }

  /**
 * @param {Array} target 目标数组
 * @param {Array} arr 需要查询的数组
 * @description 判断要查询的数组是否至少有一个元素包含在目标数组中
 */
  hasOneOf (targetarr, arr) {
    if (typeof (arr) === 'number') {
      return targetarr.indexOf(arr) > -1
    } else {
      return targetarr.some(_ => arr.indexOf(_) > -1)
    }
  }
  showThisRoute (itAccess, currentAccess) {
    if (typeof itAccess === 'object' && Array.isArray(itAccess)) {
      return this.oneOf(currentAccess, itAccess)
    } else {
      return itAccess === currentAccess
    }
  }
  getRouterObjByName (routers, name) {
    if (!name || !routers || !routers.length) {
      return null
    }
    let routerObj = null
    for (let item of routers) {
      if (item.name === name) {
        return item
      }
      routerObj = this.getRouterObjByName(item.children, name)
      if (routerObj) {
        return routerObj
      }
    }
    return null
  }
  toDefaultPage (routers, name, route, next) {
    let len = routers.length
    let i = 0
    let notHandle = true
    while (i < len) {
      if (routers[i].name === name && routers[i].children && routers[i].redirect === undefined) {
        route.replace({
          name: routers[i].children[0].name
        })
        notHandle = false
        next()
        break
      }
      i++
    }
    if (notHandle) {
      next()
    }
  }
  handleTitle (vm, item) {
    if (typeof item.meta.title === 'object') {
      return vm.$t(item.title.i18n)
    } else {
      return item.meta.title
    }
  }
  setCurrentPath (vm, name) {
    let title = ''
    let isOtherRouter = false
    vm.$store.state.app.routers.forEach((item) => {
      if (item.children.length === 1) {
        if (item.children[0].name === name) {
          title = this.handleTitle(vm, item)
          if (item.name === 'otherRouter') {
            isOtherRouter = true
          }
        }
      } else {
        item.children.forEach((child) => {
          if (child.name === name) {
            title = this.handleTitle(vm, child)
            if (item.name === 'otherRouter') {
              isOtherRouter = true
            }
          }
        })
      }
    })
    let currentPathArr = []
    if (name === 'home') {
      currentPathArr = [
        {
          meta: { title: this.handleTitle(vm, this.getRouterObjByName(vm.$store.state.app.routers, 'home')) },
          path: 'main/home',
          name: 'home'
        }
      ]
    } else if ((name.indexOf('index') >= 0 || isOtherRouter) && name !== 'home') {
      currentPathArr = [
        {
          meta: { title: this.handleTitle(vm, this.getRouterObjByName(vm.$store.state.app.routers, 'home')) },
          path: 'main/home',
          name: 'home'
        },
        {
          meta: { title: title },
          path: '',
          name: name
        }
      ]
    } else {
      let currentPathObj = vm.$store.state.app.routers.filter((item) => {
        if (item.children.length <= 1) {
          return item.children[0].name === name || item.name === name
        } else {
          let i = 0
          let childArr = item.children
          let len = childArr.length
          while (i < len) {
            if (childArr[i].name === name) {
              return true
            }
            i++
          }
          return false
        }
      })[0]
      if (currentPathObj.children && currentPathObj.children.length <= 1 && currentPathObj.name === 'home') {
        currentPathArr = [
          {
            meta: { title: 'HomePage' },
            path: 'main/home',
            name: 'home'
          }
        ]
      } else if (currentPathObj.children && currentPathObj.children.length <= 1 && currentPathObj.name !== 'home') {
        currentPathArr = [
          {
            meta: { title: 'HomePage' },
            path: 'main/home',
            name: 'home'
          },
          {
            meta: { title: currentPathObj.meta.title },
            path: '',
            name: name
          }
        ]
      } else {
        let childObj = currentPathObj.children.filter((child) => {
          return child.name === name
        })[0]
        currentPathArr = [
          {
            meta: { title: 'HomePage' },
            path: 'main/home',
            name: 'home'
          },
          {
            meta: { title: currentPathObj.meta.title },
            path: '',
            name: ''
          },
          {
            meta: { title: childObj.meta.title },
            path: currentPathObj.path + '/' + childObj.path,
            name: name
          }
        ]
      }
    }
    vm.$store.commit('app/setCurrentPath', currentPathArr)

    return currentPathArr
  }
  openNewPage (vm, name, argu, query) {
    let pageOpenedList = vm.$store.state.app.pageOpenedList
    let openedPageLen = pageOpenedList.length
    let i = 0
    let tagHasOpened = false
    while (i < openedPageLen) {
      if (name === pageOpenedList[i].name) { // 页面已经打开
        vm.$store.commit('app/pageOpenedList', {
          index: i,
          argu: argu,
          query: query
        })
        tagHasOpened = true
        break
      }
      i++
    }
    if (!tagHasOpened) {
      let tag = vm.$store.state.app.tagsList.filter((item) => {
        if (item.children) {
          return name === item.children[0].name
        } else {
          return name === item.name
        }
      })
      tag = tag[0]
      if (tag) {
        tag = tag.children ? tag.children[0] : tag
        if (argu) {
          tag.argu = argu
        }
        if (query) {
          tag.query = query
        }
        vm.$store.commit('app/increateTag', tag)
      }
    }
    vm.$store.commit('app/setCurrentPageName', name)
  }
  fullscreenEvent (vm) {
    vm.$store.commit('app/initCachepage')
    // 权限菜单过滤相关
    vm.$store.commit('app/updateMenulist')
    // 全屏相关
  }
  extend () {
    let args = arguments
    let length = arguments.length
    let options, name, src, srcType, copy, copyIsArray, clone
    let target = args[0] || {}
    let i = 1
    let deep = false
    if (typeof target === 'boolean') {
      deep = target
      target = args[i] || {}
      i++
    }
    if (typeof target !== 'object' && typeof target !== 'function') {
      target = {}
    }
    if (i === length) {
      target = this
      i--
    }
    for (; i < length; i++) {
      if ((options = args[i]) !== null) {
        for (name in options) {
          src = target[name]
          copy = options[name]
          if (target === copy) {
            continue
          }
          srcType = Array.isArray(src) ? 'array' : typeof src
          if (deep && copy && ((copyIsArray = Array.isArray(copy)) || typeof copy === 'object')) {
            if (copyIsArray) {
              copyIsArray = false
              clone = src && srcType === 'array' ? src : []
            } else {
              clone = src && srcType === 'object' ? src : {}
            }
            target[name] = this.extend(deep, clone, copy)
          } else if (copy !== undefined) {
            target[name] = copy
          }
        }
      }
    }
    return target
  }

  /**
   * @description 绑定事件 on(element, event, handler)
   */
  on (element, event, handler) {
    if (document.addEventListener) {
      if (element && event && handler) {
        element.addEventListener(event, handler, false)
      }
    } else {
      if (element && event && handler) {
        element.attachEvent('on' + event, handler)
      }
    }
  }

  /**
   * @description 解绑事件 off(element, event, handler)
   */
  off (element, event, handler) {
    if (document.removeEventListener) {
      if (element && event) {
        element.removeEventListener(event, handler, false)
      }
    } else {
      if (element && event) {
        element.detachEvent('on' + event, handler)
      }
    }
  }

  localSave = (key, value) => {
    localStorage.setItem(key, value)
  }

  localRead = (key) => {
    return localStorage.getItem(key) || ''
  }

  sessionSave = (key, value) => {
    if (typeof (value) === 'object') {
      sessionStorage.setItem(key, JSON.stringify(value))
    } else {
      sessionStorage.setItem(key, value)
    }
  }
  /*
  * 读取sessionStorage信息 IsObj 判断是否object
  */
  sessionRead = (key, IsObj) => {
    if (IsObj) {
      return JSON.parse(sessionStorage.getItem(key))
    } else {
      return sessionStorage.getItem(key)
    }
  }

  /**
 * @param {*} access 用户权限数组，如 ['super_admin', 'admin']
 * @param {*} route 路由列表
 */
  hasAccess (access, route) {
    return true
  }

  /**
 * 权鉴
 * @param {*} name 即将跳转的路由name
 * @param {*} access 用户权限数组
 * @param {*} routes 路由列表
 * @description 用户是否可跳转到该页
 */
  canTurnTo (name, access, routes) {
    const routePermissionJudge = (list) => {
      return list.some(item => {
        if (item.children && item.children.length) {
          return routePermissionJudge(item.children)
        } else if (item.name === name) {
          return this.hasAccess(access, item)
        }
      })
    }

    return routePermissionJudge(routes)
  }
  /**
   * @description 获取jwt
   */
  getToken () {

  }
}
const util = new Util()
export default util
