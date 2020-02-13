<template>
  <icon-font :type="`cm-${type}`" />
</template>
<script>
import { Icon } from 'ant-design-vue'
const IconFont = Icon.createFromIconfontCN({
  scriptUrl: '//at.alicdn.com/t/font_1598085_4urqrqvbcp6.js'
})
export default {
  props: {
    type: String
  },
  components: {
    IconFont
  }
}
</script>
