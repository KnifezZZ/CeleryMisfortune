<template>
  <a-table
    :rowKey="record=>record.id"
    bordered
    :dataSource="dataSource"
    :columns="columns"
    :pagination="pagination"
  >
    <template slot="tag" slot-scope="text">
      <a-tag :color="text?'green':'red'" key="text">{{text}}</a-tag>
    </template>

    <template slot="link" slot-scope="text">
      <a :href="text">{{text}}</a>
    </template>

    <template slot="icon" slot-scope="text">
      <a-icon :type="text" />
    </template>

    <template slot="rate" slot-scope="text">
      <a-rate :defaultValue="text" disabled allowHalf />
    </template>

    <template slot="badge" slot-scope="text">
      <a-badge status="success" />
      {{text}}
    </template>

    <template slot="operation" slot-scope="text, record">
      <a-button type="primary" @click="onModify(record.id)">编辑</a-button>
      <a-popconfirm v-if="dataSource.length" title="确定要删除吗?" @confirm="() => onDelete(record.id)">
        <a-button href="javascript:;" type="danger">删除</a-button>
      </a-popconfirm>
    </template>
  </a-table>
</template>
<script>
export default {
  name: 'Dtable',
  props: {
    columns: { type: Array, default: () => [] },
    dataSource: { type: Array, default: () => [] },
    pagination: {
      type: Object,
      default: function () {
        return {
          showQuickJumper: true,
          showSizeChanger: true,
          showTotal: total => `共 ${total} 条`,
          pageSize: 10,
          pageSizeOptions: ['10', '20', '50', '100', '200']
        }
      }
    },
    totalCount: Number
  },
  methods: {
    onDelete (id) {
      this.$emit('onDelete')
    },
    onModify (id) {
      this.$emit('onModify')
    }
  },
  mounted () {
  }
}
</script>
