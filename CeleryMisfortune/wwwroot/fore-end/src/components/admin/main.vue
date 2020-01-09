<template>
  <a-layout id="components-layout-demo-side" style="height: 100vh">
    <a-layout-sider :trigger="null" collapsible v-model="collapsed">
      <div class="logo" />
      <a-menu
        theme="dark"
        mode="inline"
        @click="handleClick"
        :defaultSelectedKeys="clickedItem"
        :openKeys.sync="openKeys"
      >
        <template v-for="item in menuList">
          <a-menu-item v-if="!item.children" :key="item.name">
            <a-icon :type="item.meta.icon" />
            <span>{{item.title}}</span>
          </a-menu-item>
          <sub-menu v-else :menu-info="item" :key="item.name" />
        </template>
      </a-menu>
    </a-layout-sider>
    <a-layout>
      <a-layout-header style="background: #fff; padding: 0">
        <a-icon
          class="trigger"
          :type="collapsed ? 'menu-unfold' : 'menu-fold'"
          @click="()=> collapsed = !collapsed"
        />
      </a-layout-header>
      <a-layout-content
        :style="{ margin: '24px 16px', padding: '24px', background: '#fff', minHeight: '280px',overflow: 'initial' }"
      >
        <router-view />
      </a-layout-content>
      <a-layout-footer v-if="$config.showFooter" style="textAlign: center">{{$config.footerInfo}}</a-layout-footer>
    </a-layout>
  </a-layout>
</template>
<script>
import SubMenu from './components/sub-menu/index'
import { filterMenu } from '@/utils/router-util'
export default {
  data () {
    return {
      collapsed: false,
      openKeys: ['admin'],
      clickedItem: [JSON.stringify(localStorage.getItem('currMenuItem'))]
    }
  },
  components: {
    'sub-menu': SubMenu
  },
  computed: {
    menuList () {
      return filterMenu(JSON.parse(localStorage.getItem('routerStorage')))
    }
  },
  methods: {
    handleClick (e) {
      console.log('click', e)
      localStorage.setItem('currMenuItem', e.key)
      this.$router.push({ name: e.key })
    },
    titleClick (e) {
      console.log('titleClick', e)
    },

    turnToPage (route) {
      let { name, params, query } = {}
      if (typeof route === 'string') {
        this.$router.options.routes.forEach(ele => {
          if (typeof (ele.children) !== 'undefined') {
            let tmp = ele.children.find(function (x) {
              return x.name === route
            })
            if (typeof (tmp) !== 'undefined') {
              params = tmp.params
              query = tmp.query
            }
          }
        })
        name = route
      } else {
        name = route.name
        params = route.params
        query = route.query
      }
      if (name.indexOf('isTurnByHref_') > -1) {
        window.open(name.split('_')[1])
        return
      }
      this.$router.push({
        name,
        params,
        query
      })
    }
  },

  mounted () {
    let vm = this
    setTimeout(() => {
      debugger
      window.abp.signalr.hubs.common.invoke('SendMessage', 'hello').catch(function (err) {
        return console.error(err.toString())
      })
      window.abp.signalr.hubs.common.on('ReceiveMessage', function (message) {
        var msg = message.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;')
        vm.$info({ title: msg })
      })
    }, 2000)
  }
}
</script>
<style>
#components-layout-demo-side .logo {
  height: 32px;
  background: rgba(255, 255, 255, 0.2);
  margin: 16px;
}
#components-layout-demo-side .trigger {
  font-size: 18px;
  line-height: 64px;
  padding: 0 24px;
  cursor: pointer;
  transition: color 0.3s;
}
</style>
