<template>
  <div>
    <a-steps :current="current" style="display:none">
      <a-step v-for="item in steps" :key="item.title" :title="item.title" />
    </a-steps>
    <div class="steps-content">
      <h3>{{steps[current].title}}</h3>
      {{steps[current].content}}
      <a-input v-model="currentSelect"></a-input>
    </div>
    <div class="steps-action">
      <a-button v-if="current < steps.length - 1" type="primary" @click="next">继续</a-button>
      <a-button
        v-if="current == steps.length - 1"
        type="primary"
        @click="$message.success('Processing complete!')"
      >完成</a-button>
      <a-button v-if="current>0" style="margin-left: 8px" @click="prev">返回</a-button>
    </div>
  </div>
</template>
<script>
export default {
  data () {
    return {
      current: 0,
      model: [],
      currentSelect: '',
      steps: [
        {
          title: '敢问少侠尊姓大名',
          content: '行走江湖功夫如何不重要，重要的是名字要响当当！',
          key: 'name',
          value: ''
        },
        {
          title: '少侠请决定是男是女',
          content: ''
        },
        {
          title: 'Last',
          content: 'Last-content'
        }
      ]
    }
  },
  methods: {
    next () {
      this.current++
    },
    prev () {
      this.current--
    }
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
