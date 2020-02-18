<template>
  <div>
    <a-row align="middle" style="margin-top:5px">
      <a-col :span="12">
        <a-button size="small">{{this.playerInfo.Infos.NickName}}</a-button>
        <span>{{this.playerInfo.Infos.Name}}</span>
      </a-col>
      <a-col :span="12" style="text-align:right;height:24px">
        <i class="iconfont cm-yushi kz-yellow"></i>
        <span>{{this.playerInfo.State.Money}}</span>
        &nbsp;&nbsp;
        <i class="iconfont cm-bowlder kz-pink"></i>
        <span>{{this.playerInfo.State.Gold}}</span>
      </a-col>
      <a-col :span="12" :md="12" :xl="6" :xxl="4">
        <span>寿元</span>
        <span class="kz-blue">[{{this.playerInfo.State.LifeRemark}}]</span>
      </a-col>
      <a-col :span="12" :md="12" :xl="6" :xxl="4">
        <span>精力</span>
        <span>[{{this.playerInfo.State.Energy}}]</span>
      </a-col>
      <a-col :span="12" :md="12" :xl="6" :xxl="4">
        <span>境界</span>
        <span class="kz-pink">[{{this.playerInfo.State.StateLevel}}]</span>
      </a-col>
      <a-col :span="12" :md="12" :xl="6" :xxl="4">
        <span>状态</span>
        <span class="kz-green">[健康]</span>
      </a-col>
    </a-row>
    <a-row :gutter="24">
      <a-divider>
        <i class="iconfont cm-shuxing kz-red"></i>
        <a-tooltip title="~~" :getPopupContainer="getPopupContainer">基本信息</a-tooltip>
      </a-divider>
      <a-col
        v-for="item in this.playerInfo.Attributes"
        :key="item.ID"
        :span="8"
        :md="12"
        :xl="6"
        :xxl="4"
      >
        <span>{{item.AttrName}}</span>
        <span>{{item.AttrValue}}</span>
      </a-col>
    </a-row>
    <a-row :gutter="24">
      <a-divider>
        <i class="iconfont cm-shuxing kz-red"></i>
        <a-tooltip title="万物根基，决定其他属性的效果大小" :getPopupContainer="getPopupContainer">根骨</a-tooltip>
      </a-divider>
      <ul class="Property">
        <li>
          <a-tooltip title="提升你的神识大小和强度" :getPopupContainer="getPopupContainer">
            <strong>精神</strong>
            {{this.playerInfo.Special.Perception}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="关系到生命值和体修类难度" :getPopupContainer="getPopupContainer">
            <strong>体魄</strong>
            {{this.playerInfo.Special.Endurance}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="关系到人物友好度和幸运值" :getPopupContainer="getPopupContainer">
            <strong>魅力</strong>
            {{this.playerInfo.Special.Charisma}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="聪慧程度" :getPopupContainer="getPopupContainer">
            <strong>悟性</strong>
            {{this.playerInfo.Special.Intelligence}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="关系到人物友好度和幸运值" :getPopupContainer="getPopupContainer">
            <strong>身法</strong>
            {{this.playerInfo.Special.Agility}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="不可名状的效果，玄学" :getPopupContainer="getPopupContainer">
            <strong>福源</strong>
            {{this.playerInfo.Special.Luck}}
          </a-tooltip>
        </li>
      </ul>
    </a-row>
    <a-progress :percent="10" />
  </div>
</template>

<script>
import { GetPlayerUnitInfoById } from '@/api/player'
export default {
  data () {
    return {
      playerInfo: []
    }
  },
  methods: {
    getPopupContainer (trigger) {
      return trigger.parentElement
    },
    getPlayerInfo () {
      let vm = this
      if (this.$store.state.user.currUser === '') {
        this.$router.push({
          name: vm.$config.homePage
        })
      } else {
        GetPlayerUnitInfoById(this.$store.state.user.currUser).then(res => {
          debugger
          vm.playerInfo = res.data
        })
      }
    }
  },
  mounted () {
    this.getPlayerInfo()
  }
}
</script>

<style lang="less" scoped>
h3 {
  text-align: center;
}
.Property {
  li {
    position: relative;
    float: left;
    width: 33%;
    strong {
      font-weight: 400;
      color: #0dbc79;
    }
    strong::after {
      content: "\00a0\00a0";
    }
  }
}
</style>
