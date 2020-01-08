<template>
  <div>
    <a-row :gutter="12">
      <a-col :xs="24" :sm="12" :xl="8">
        <p>
          <br />一卷道元真解，
          <br />暗藏大道玄机，
          <br />一术推洐万法，
          <br />三千大道在胸。
          <br />寒门少年崛起，苦读十年窥得真经！
          <br />终得一剑出玄黄，只手护苍生！
          <br />三千年大劫降世，亦只作掌中神兵，
          <br />从此仙路上，谁敢撄其锋？
        </p>
        <h2>
          <a-icon type="thunderbolt" />应劫者降临
        </h2>
        <a-icon type="notification" />请选择你的身份
      </a-col>
    </a-row>

    <a-row :gutter="16" v-if="hasRoler">
      <a-col
        style="margin-top:8px"
        :span="8"
        :xs="24"
        :md="12"
        :xl="6"
        :xxl="4"
        v-for="item in playerRoleData"
        :key="item.ID"
      >
        <a-card hoverable>
          <template class="ant-card-actions" slot="actions">
            <a-icon type="eye" @click="ShowSpecialItem(item.ID)" />
            <a-icon type="login" @click="StartGame(item.ID)" />
          </template>
          <a-card-meta :title="item.Name" :description="item.NickName">
            <icon-font :type="item.BirthPlace" slot="avatar" style="font-size:32px" />
          </a-card-meta>
        </a-card>
      </a-col>
    </a-row>
    <a-row :gutter="16" v-else>
      <a-col
        style="margin-top:8px"
        :span="8"
        :xs="24"
        :md="12"
        :xl="6"
        :xxl="4"
        v-for="item in playerRoleData"
        :key="item.id"
      >
        <a-card hoverable>
          <template class="ant-card-actions" slot="actions">
            <a-icon type="eye" @click="ShowSpecialItem(item.id)" />
            <a-icon type="login" @click="StartGame(item.id)" />
          </template>
          <a-card-meta :title="item.detail.name" :description="item.detail.description">
            <icon-font :type="item.detail.avatar" slot="avatar" style="font-size:32px" />
          </a-card-meta>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script>
import IconFont from '@/components/icon'
import { GetMockJson } from '@/api/app'
import { Search } from '@/api/player'
export default {
  name: 'Index',
  components: {
    IconFont
  },
  data () {
    return {
      env: process.env.NODE_ENV,
      envName: process.env.ENV_NAME,
      hasRoler: false,
      playerRoleData: []
    }
  },
  methods: {
    StartGame (id) {
      this.$info({ title: '你选择了--' + id })
    },
    ShowSpecialItem (id) {
      this.$info({ title: '你选择了--' + id })
    }
  },
  mounted () {
    Search({
      CreateBy: this.$store.state.user.userAccount,
      Page: 1,
      Limit: 5
    }).then(res => {
      debugger
      if (res.data.Count > 0) {
        this.hasRoler = true
        this.playerRoleData = res.data.Data
      } else {
        // 获取角色列表
        GetMockJson('player').then(res => {
          this.playerRoleData = res.data
        })
      }
    })
  }

}
</script>
<style scoped>
.ant-card-hoverable:hover {
  border-color: rgba(32, 114, 190, 0.89);
  box-shadow: 10px 10px 10px rgba(113, 178, 238, 0.89);
}
</style>
