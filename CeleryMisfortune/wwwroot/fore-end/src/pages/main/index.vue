<template>
  <div>
    <a-row align="middle" style="margin-top:5px">
      <a-col :span="12">
        <a-button size="small">{{this.playerInfo.NickName}}</a-button>
        <span>{{this.playerInfo.Name}}</span>
      </a-col>
      <a-col :span="12" style="text-align:right;height:24px">
        <i class="iconfont cm-yushi kz-yellow"></i>
        <span>10</span>
        &nbsp;&nbsp;
        <i class="iconfont cm-bowlder kz-pink"></i>
        <span>0</span>
      </a-col>
      <a-col :span="12" :md="12" :xl="6" :xxl="4">
        <span>寿元</span>
        <span class="kz-blue">[正值年少]</span>
      </a-col>
      <a-col :span="12" :md="12" :xl="6" :xxl="4">
        <span>精力</span>
        <span>[100]</span>
      </a-col>
      <a-col :span="12" :md="12" :xl="6" :xxl="4">
        <span>境界</span>
        <span class="kz-pink">[练气大圆满]</span>
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
      <a-col :span="8" :md="12" :xl="6" :xxl="4">
        <span>门派</span>
        <span>[无门无派]</span>
      </a-col>
      <a-col :span="16" :md="12" :xl="6" :xxl="4">
        <span>出身</span>
        <span>[{{this.playerInfo.BirthPlace}}]</span>
      </a-col>
      <a-col :span="8" :md="12" :xl="6" :xxl="4">
        <span>神识</span>
        <span>[100]</span>
      </a-col>
      <a-col :span="8" :md="12" :xl="6" :xxl="4">
        <span>气血</span>
        <span>[100]</span>
      </a-col>
      <a-col :span="8" :md="12" :xl="6" :xxl="4">
        <span>丹毒</span>
        <span>[0]</span>
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
            {{this.playerSpecial.Perception}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="关系到生命值和体修类难度" :getPopupContainer="getPopupContainer">
            <strong>体魄</strong>
            {{this.playerSpecial.Endurance}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="关系到人物友好度和幸运值" :getPopupContainer="getPopupContainer">
            <strong>魅力</strong>
            {{this.playerSpecial.Charisma}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="聪慧程度" :getPopupContainer="getPopupContainer">
            <strong>悟性</strong>
            {{this.playerSpecial.Intelligence}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="关系到人物友好度和幸运值" :getPopupContainer="getPopupContainer">
            <strong>身法</strong>
            {{this.playerSpecial.Agility}}
          </a-tooltip>
        </li>
        <li>
          <a-tooltip title="不可名状的效果，玄学" :getPopupContainer="getPopupContainer">
            <strong>福源</strong>
            {{this.playerSpecial.Luck}}
          </a-tooltip>
        </li>
      </ul>
    </a-row>
    <a-progress :percent="10" />
  </div>
</template>

<script>
import { GetPlayerInfoById, GetPlayerSpecialInfo } from '@/api/player'
export default {
  data () {
    return {
      playerInfo: [],
      playerSpecial: []
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
        GetPlayerInfoById(this.$store.state.user.currUser).then(res => {
          vm.playerInfo = res.data.Entity
          GetPlayerSpecialInfo({
            FK_PlayerGuid: this.$store.state.user.currUser
          }).then(special => {
            vm.playerSpecial = special.data.Data[0]
          })
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
