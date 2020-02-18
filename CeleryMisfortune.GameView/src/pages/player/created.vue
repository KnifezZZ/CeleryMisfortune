<template>
  <div>
    <a-steps :current="current" style="display:none">
      <a-step v-for="item in steps" :key="item.title" :title="item.title" />
    </a-steps>
    <div class="steps-content">
      <!-- :typeSpeed="240" -->
      <vue-typed-js :key="current" :strings="[steps[current].content]" @onComplete="showButton()">
        <h3>
          &nbsp;&nbsp;
          <span class="typing"></span>
        </h3>
      </vue-typed-js>
      <a-row>
        <a-col v-show="current===2&&isTypedOk">
          <a-input v-model="model.Name" placeholder="请输入你的姓名"></a-input>
        </a-col>
        <a-col v-show="current===2&&isTypedOk">
          <h4>你是</h4>
          <a-radio-group v-model="model.BirthPlace" defaultValue="Human" buttonStyle="solid">
            <a-radio-button value="Human">人族</a-radio-button>
            <a-radio-button value="Animal" disabled>妖族</a-radio-button>
          </a-radio-group>
          <a-radio-group v-model="model.Sex" v-decorator="['radio-group']">
            <a-radio value="1">男</a-radio>
            <a-radio value="2">女</a-radio>
            <a-radio value="3">未知</a-radio>
          </a-radio-group>
        </a-col>
        <a-col v-show="current===2&&isTypedOk">
          <h3>初始灵根</h3>
          <a-radio-group v-model="model.BodySprit" v-decorator="['radio-group']">
            <a-radio value="2">金</a-radio>
            <a-radio value="3">木</a-radio>
            <a-radio value="4">水</a-radio>
            <a-radio value="5">火</a-radio>
            <a-radio value="6">土</a-radio>
            <a-radio value="7">混元</a-radio>
          </a-radio-group>
        </a-col>
        <a-col v-show="current===3&&isTypedOk">
          <!-- <h3>经历特质</h3> -->
          <p v-show="model.Trait==='1'">
            少时多病，时长自医，你的
            <span class="kz-red">炼丹</span>技能颇为不俗，但
            <span class="kz-red">体质不会太高</span>
          </p>
          <p v-show="model.Trait==='2'">你在一个深山中的洞穴中寻得一瓶丹药</p>
          <p v-show="model.Trait==='3'">你拥有一件家传灵物</p>
          <a-radio-group v-model="model.Trait" v-decorator="['radio-group']">
            <a-radio value="1">九折成医</a-radio>
            <a-radio value="2">灰炉遗丹</a-radio>
            <a-radio value="3">家传宝物</a-radio>
          </a-radio-group>
        </a-col>
      </a-row>
    </div>
    <div class="steps-action">
      <a-button v-if="current < steps.length - 1&&isTypedOk" type="primary" @click="next">继续</a-button>
      <a-button v-if="current == steps.length - 1" type="primary" @click="submit">完成</a-button>
      <!-- <a-button v-if="current>0" style="margin-left: 8px" @click="prev">返回</a-button> -->
    </div>
  </div>
</template>
<script>
import { CreatedPlayer } from '@/api/player'
export default {
  data () {
    return {
      current: 0,
      model: {
        Name: '',
        Sex: 0,
        BrithPlace: '',
        BodySprit: '',
        Trait: ''
      },
      isTypedOk: false,
      currentSelect: '',
      steps: [{
        content: '大劫厉8967年春，西荒魔渊异动，黑暗生灵再度降世，肆虐人间，先辈修士仗剑入原，鏖战数年，终逐黑暗生灵回魔渊，还天地一份安宁'
      }, {
        content: '据传二百年前昆仑顶修行界高手齐聚，共同研究永化大劫的方法，但一场湮雷降世之后，昆仑顶不复存在，修行界力量十不存一，传承断了无数，仅存一些残经断章，便是金丹小辈，也可称宗做祖了。<br>我们还能抵御下一次大劫吗？'
      },
      {
        content: '启元326年，一个婴儿呱呱落地',
        key: 'name',
        pretext: '请输入你的姓名'
      },
      {
        content: '一晃15年,'
      },
      {
        title: 'Last',
        content: 'Last-content'
      }
      ]
    }
  },
  methods: {
    showButton () {
      this.isTypedOk = true
    },
    next () {
      this.isTypedOk = false
      this.current++
    },
    prev () {
      this.current--
    },
    submit () {
      CreatedPlayer(this.model).then(res => {
        debugger
        this.$router.push({
          name: 'main-page'
        })
      })
    }
  },
  mounted () {

  }
}
</script>
<style scoped>
.steps-content {
  margin-top: 16px;
  border: 1px dashed #e9e9e9;
  border-radius: 6px;
  background-color: #fafafa;
  min-height: 200px;
  text-align: center;
  padding-top: 10px;
}

.steps-action {
  margin-top: 24px;
}
</style>
