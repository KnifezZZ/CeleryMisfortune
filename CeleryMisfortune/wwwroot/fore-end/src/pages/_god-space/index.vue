<template>
  <div>
    <a-row :gutter="24">
      <a-col style="margin-top:8px" :span="8" :xs="24" :md="12" :xl="6" :xxl="4">
        <a-card title="纳戒" :bordered="false">
          <p>门派弟子标配</p>
          <a-button @click="()=> isBagOpen = !isBagOpen">打开</a-button>

          <a-radio-group v-model="mode" :style="{ marginBottom: '8px' }">
            <a-radio-button value="top">Horizontal</a-radio-button>
            <a-radio-button value="left">Vertical</a-radio-button>
          </a-radio-group>
          <a-tabs
            v-if="isBagOpen"
            defaultActiveKey="star"
            :tabPosition="mode"
            :style="{ height: '400px'}"
            @prevClick="callback"
            @nextClick="callback"
          >
            <a-tab-pane tab="星标" key="star" style="padding:10px;">
              <a-table
                :columns="columns"
                :rowKey="record => record.uuid"
                :dataSource="data"
                @change="onChange"
              >
                <!-- <template slot="name" slot-scope="name">{{name.first}} {{name.last}}</template> -->
              </a-table>
            </a-tab-pane>
            <a-tab-pane tab="武器" key="wq">Content of tab 2</a-tab-pane>
            <a-tab-pane tab="丹药" key="3">Content of tab 3</a-tab-pane>
            <a-tab-pane tab="装备" key="4">Content of tab 3</a-tab-pane>
            <a-tab-pane tab="符箓" key="5">Content of tab 3</a-tab-pane>
            <a-tab-pane tab="其他" key="6">Content of tab 3</a-tab-pane>
          </a-tabs>
        </a-card>
      </a-col>
      <a-col style="margin-top:8px" :span="8" :xs="24" :md="12" :xl="6" :xxl="4">
        <a-card title="Card title" :bordered="false">
          <p>card content</p>
        </a-card>
      </a-col>
      <a-col style="margin-top:8px" :span="8" :xs="24" :md="12" :xl="6" :xxl="4">
        <a-card title="Card title" :bordered="false">
          <p>card content</p>
        </a-card>
      </a-col>
      <a-col style="margin-top:8px" :span="8" :xs="24" :md="12" :xl="6" :xxl="4">
        <a-card title="Card title" :bordered="false">
          <p>card content</p>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script>
const columns = [
  {
    title: '名称',
    dataIndex: 'title'
    // scopedSlots: { customRender: 'name' }
  },
  {
    title: '伤害',
    dataIndex: 'aggressivity',
    width: '26%',
    sorter: (a, b) => a.aggressivity - b.aggressivity
  },
  {
    title: '重量',
    dataIndex: 'value',
    width: '26%',
    sorter: (a, b) => a.aggressivity - b.aggressivity
  }
]
export default {
  data () {
    return {
      mode: 'top',
      isBagOpen: true,
      data: [
        {
          uuid: 1,
          title: '桃木剑',
          type: 'wq',
          aggressivity: 10
        },
        {
          uuid: 2,
          title: '铁木剑',
          type: 'wq',
          aggressivity: 30
        },
        {
          uuid: 3,
          title: '飞雷剑',
          type: 'wq',
          aggressivity: 99999
        },
        {
          uuid: 4,
          title: '九天十地灭绝神魔飞凌剑',
          type: 'wq',
          aggressivity: 99999
        }
      ],
      columns
    }
  },
  methods: {
    onChange (pagination, filters, sorter) {
      console.log('params', pagination, filters, sorter)
    },
    callback (val) {
      console.log(val)
    }
  }
}
</script>

<style>
</style>
