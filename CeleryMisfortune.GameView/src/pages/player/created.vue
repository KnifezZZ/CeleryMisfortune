<template>
  <div>
    <a-steps :current="current" style="display:none">
      <a-step v-for="item in steps" :key="item.title" :title="item.title" />
    </a-steps>
    <div class="steps-content">
      <vue-typed-js
        :key="current"
        :typeSpeed="240"
        :strings="[steps[current].content]"
        @onComplete="showButton()"
      >
        <h3>
          &nbsp;&nbsp;
          <span class="typing"></span>
        </h3>
      </vue-typed-js>
      <a-input
        v-show="this.isTypedOk&&steps[current].key!==''"
        v-model="currentSelect"
        :placeholder="steps[current].pretext"
      ></a-input>
    </div>
    <div class="steps-action">
      <a-button v-if="current < steps.length - 1&&isTypedOk" type="primary" @click="next">继续</a-button>
      <a-button
        v-if="current == steps.length - 1"
        type="primary"
        @click="$message.success('Processing complete!')"
      >完成</a-button>
      <!-- <a-button v-if="current>0" style="margin-left: 8px" @click="prev">返回</a-button> -->
    </div>
  </div>
</template>
<script>
export default {
  data () {
    return {
      current: 0,
      model: [],
      isTypedOk: false,
      currentSelect: '',
      steps: [{
        content: '大劫厉9299年春，西荒魔渊异动，黑暗生灵再度降世，肆虐人间，先辈修士仗剑入原，鏖战数年，终逐黑暗生灵回魔渊，还天地一份安宁',
        key: ''
      },
      {
        content: '启元326年，一个婴儿呱呱落地',
        key: 'name',
        pretext: '请输入你的姓名',
        value: ''
      },
      {
        content: '启元326年，一个婴儿呱呱落地',
        key: 'sex',
        pretext: '请决定你的性别',
        value: ''
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
