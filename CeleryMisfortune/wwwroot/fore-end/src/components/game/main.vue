<template>
  <a-layout id="layout-cm-fixed">
    <a-layout-header :style="{ position: 'fixed', zIndex: 1, width: '100%' }">
      <div class="logo">
        <a-avatar
          shape="square"
          size="large"
          :style="{backgroundColor: '#00a2ae', verticalAlign: 'middle'}"
        >大劫主</a-avatar>
      </div>
      <a-menu
        id="head-menu"
        theme="dark"
        mode="horizontal"
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
    </a-layout-header>
    <a-layout-content :style="{ padding: '0 50px', marginTop: '64px' }">
      <router-view />
    </a-layout-content>
    <a-layout-footer v-if="$config.showFooter" style="textAlign: center">{{$config.footerInfo}}</a-layout-footer>
  </a-layout>
</template>
<script>

import SubMenu from '@/components/admin/components/sub-menu/index'
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
  }
}
</script>
<style>
#layout-cm-fixed .logo {
  height: 40px;
  line-height: 40px;
  margin: 8px;
  float: left;
}
#head-menu li {
  line-height: 62px;
}
.ant-layout-header {
  padding: 0px 15px;
}
</style>
