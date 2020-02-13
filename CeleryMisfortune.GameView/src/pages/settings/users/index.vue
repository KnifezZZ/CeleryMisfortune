<template>
  <div>
    <a-row style="margin-bottom:5px">
      <a-col :xs="20" :sm="16" :md="12" :xl="6">
        <a-button @click="handleAdd">新增</a-button>
      </a-col>
    </a-row>
    <!-- <a-table
      :rowKey="record=>record.id"
      bordered
      :dataSource="dataSource"
      :columns="columns"
      :pagination="{
        showQuickJumper:true,
        showSizeChanger:true,
        total:totalCount,
        showTotal:total => `共 ${total} 条`,
        pageSizeOptions:['10','50','100','200','500']
      }"
      @change="pageChange"
    >
      <template slot="operation" slot-scope="text, record">
        <a-button type="primary" @click="onModify(record.id)">编辑</a-button>
        <a-popconfirm v-if="dataSource.length" title="确定要删除吗?" @confirm="() => onDelete(record.id)">
          <a-button href="javascript:;" type="danger">删除</a-button>
        </a-popconfirm>
      </template>
    </a-table>-->

    <dtable
      :columns="columns"
      :dataSource="dataSource"
      :pageChange="pageChange"
      @onModify="onModify"
    ></dtable>
  </div>
</template>
<script>
import Dtable from '@/components/dynamic-page'
import { GetPaged, Delete } from '@/api/user'
export default {
  components: {
    Dtable
  },
  data () {
    return {
      totalCount: 0,
      dataSource: [],
      columns: []
    }
  },
  methods: {
    onCellChange (key, dataIndex, value) {
      const dataSource = [...this.dataSource]
      const target = dataSource.find(item => item.key === key)
      if (target) {
        target[dataIndex] = value
        this.dataSource = dataSource
      }
    },
    pageChange (page) {
      GetPaged(page.current, page.pageSize).then(res => {
        this.dataSource = res.data.result.items
        this.totalCount = res.data.result.totalCount
      })
    },
    onDelete (key) {
      Delete(key).then(res => {
        this.pageChange({ current: 1, pageSize: 10 })
      })
    },
    onModify (key) {
      this.$router.push({
        name: 'userModify',
        query: {
          id: key
        }
      })
    },
    handleAdd () {
      this.$router.push({
        name: 'userModify',
        query: {
          id: 0
        }
      })
    }
  },
  mounted () {
    this.columns = [{
      title: '编号',
      dataIndex: 'id'
    },
    {
      title: '账户',
      dataIndex: 'userName'
    },
    {
      title: '姓',
      dataIndex: 'surname'
    },
    {
      title: '名',
      dataIndex: 'name'
    },
    {
      title: '是否激活',
      dataIndex: 'isActive',
      scopedSlots: { customRender: 'tag' }
    },
    {
      title: '邮箱',
      dataIndex: 'emailAddress'
    },
    {
      title: '创建时间',
      dataIndex: 'creationTime'
    },
    {
      title: 'operation',
      dataIndex: 'operation',
      scopedSlots: { customRender: 'operation' }
    }
    ]
    this.pageChange({ current: 1, pageSize: 10 })
  }
}
</script>
