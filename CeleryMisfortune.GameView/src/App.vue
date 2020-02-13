<template>
  <a-locale-provider :locale="locale">
    <div id="app" style="height: 100%">
      <router-view />
    </div>
  </a-locale-provider>
</template>

<script>
import zhCN from 'ant-design-vue/lib/locale-provider/zh_CN'
export default {
  name: 'App',
  data () {
    return {
      locale: zhCN
    }
  }
}
</script>
