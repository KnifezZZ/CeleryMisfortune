<template>
  <a-layout style="padding: 24px 0; background: #fff">
    <a-layout-sider width="400" style="background: #fff">
      <h2>菜单</h2>
      <a-tree
        class="draggable-tree"
        :defaultExpandAll="true"
        draggable
        :showLine="true"
        @dragenter="onDragEnter"
        @drop="onDrop"
        @select="onSelect"
        :treeData="gData"
      />
    </a-layout-sider>
    <a-layout-content :style="{ padding: '0 24px', minHeight: '480px' }">
      <a-form :form="form" @submit="handleSubmit">
        <a-form-item label="菜单标识" :label-col="{ span: 5 }" :wrapper-col="{ span: 12 }">
          <a-input
            v-decorator="['name', { rules: [{ required: true, message: 'Please input your note!' }] }]"
          />
        </a-form-item>
        <a-form-item label="菜单标题" :label-col="{ span: 5 }" :wrapper-col="{ span: 12 }">
          <a-input
            v-decorator="['title', { rules: [{ required: true, message: 'Please input your note!' }] }]"
          />
        </a-form-item>
        <a-form-item label="路由Path" :label-col="{ span: 5 }" :wrapper-col="{ span: 12 }">
          <a-input
            v-decorator="['path', { rules: [{ required: true, message: 'Please input your note!' }] }]"
          />
        </a-form-item>
        <a-form-item label="页面路径" :label-col="{ span: 5 }" :wrapper-col="{ span: 12 }">
          <a-input v-decorator="['component', { }]" />
        </a-form-item>
        <a-form-item label="菜单隐藏" :label-col="{ span: 5 }" :wrapper-col="{ span: 12 }">
          <a-switch v-decorator="['hideInMenu', { valuePropName: 'checked' }]" />
        </a-form-item>
        <a-form-item label="菜单图标" :label-col="{ span: 5 }" :wrapper-col="{ span: 12 }">
          <icon-selector v-decorator="['icon', { }]"></icon-selector>
        </a-form-item>
        <a-form-item :wrapper-col="{ span: 12, offset: 5 }">
          <a-button type="primary" html-type="submit">保存</a-button>
        </a-form-item>
      </a-form>
    </a-layout-content>
  </a-layout>
</template>
<script>
import IconSelector from '@/components/icon-selector/icon-selector'
import { GetRouterJson } from '@/api/app'
import { GetTreeNode, UpdateTreeNode } from '@/utils/router-util'
export default {
  data () {
    return {
      gData: [],
      isSaved: true,
      expandedKeys: [],
      form: this.$form.createForm(this, { name: 'coordinated' })
    }
  },
  components: {
    IconSelector
  },
  methods: {
    initData () {
      GetRouterJson().then(res => {
        this.gData = res.data
      })
    },
    handleSubmit (e) {
      e.preventDefault()
      let data = this.gData
      this.form.validateFields((err, values) => {
        if (!err) {
          console.log('Received values of form: ', values)
          data = UpdateTreeNode(data, values)
          var curNode = GetTreeNode(data, values.name)
          console.log('Received values of form: ', curNode)
        }
      })
    },
    onSelect (node, e) {
      let data = {
        name: e.selectedNodes[0].data.props.dataRef.name,
        path: e.selectedNodes[0].data.props.dataRef.path,
        title: e.selectedNodes[0].data.props.dataRef.title,
        component: e.selectedNodes[0].data.props.dataRef.component,
        hideInMenu: e.selectedNodes[0].data.props.dataRef.meta.hideInMenu,
        icon: e.selectedNodes[0].data.props.dataRef.meta.icon
      }
      this.form.setFieldsValue(data)
    },
    onDragEnter (info) {
      console.log(info)
      // expandedKeys 需要受控时设置
      // this.expandedKeys = info.expandedKeys
    },
    onDrop (info) {
      console.log(info)
      const dropKey = info.node.eventKey
      const dragKey = info.dragNode.eventKey
      const dropPos = info.node.pos.split('-')
      const dropPosition = info.dropPosition - Number(dropPos[dropPos.length - 1])
      const loop = (data, key, callback) => {
        data.forEach((item, index, arr) => {
          if (item.key === key) {
            return callback(item, index, arr)
          }
          if (item.children) {
            return loop(item.children, key, callback)
          }
        })
      }
      const data = this.gData
      // Find dragObject
      let dragObj
      loop(data, dragKey, (item, index, arr) => {
        arr.splice(index, 1)
        dragObj = item
      })
      if (!info.dropToGap) {
        // Drop on the content
        loop(data, dropKey, item => {
          item.children = item.children || []
          // where to insert 示例添加到尾部，可以是随意位置
          item.children.push(dragObj)
        })
      } else if (
        (info.node.children || []).length > 0 && // Has children
        info.node.expanded && // Is expanded
        dropPosition === 1 // On the bottom gap
      ) {
        loop(data, dropKey, item => {
          item.children = item.children || []
          // where to insert 示例添加到尾部，可以是随意位置
          item.children.unshift(dragObj)
        })
      } else {
        let ar
        let i
        loop(data, dropKey, (item, index, arr) => {
          ar = arr
          i = index
        })
        if (dropPosition === -1) {
          ar.splice(i, 0, dragObj)
        } else {
          ar.splice(i + 1, 0, dragObj)
        }
      }
    }
  },
  mounted () {
    this.initData()
  }
}
</script>
