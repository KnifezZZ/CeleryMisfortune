<template>
  <div class="container">
    <div class="content">
      <div class="top">
        <div class="header">
          <a>
            <span class="title">
              <a-icon type="rocket" style="margin-right:5px" />
              {{$config.headTitle}}
            </span>
          </a>
        </div>
        <div class="desc">{{$config.description}}</div>
      </div>
      <div class="main">
        <a-form
          id="components-form-demo-normal-login"
          :form="form"
          class="login-form"
          @submit="handleSubmit"
        >
          <a-form-item>
            <a-input
              v-decorator="[
          'userName',
          { rules: [{ required: true, message: 'Please input your username!' }] },
        ]"
              placeholder="Username"
            >
              <a-icon slot="prefix" type="user" style="color: rgba(0,0,0,.25)" />
            </a-input>
          </a-form-item>
          <a-form-item>
            <a-input
              v-decorator="[
          'password',
          { rules: [{ required: true, message: 'Please input your Password!' }] },
        ]"
              type="password"
              placeholder="Password"
            >
              <a-icon slot="prefix" type="lock" style="color: rgba(0,0,0,.25)" />
            </a-input>
          </a-form-item>
          <a-form-item>
            <a-checkbox
              v-decorator="[
          'remember',
          {
            valuePropName: 'checked',
            initialValue: true,
          },
        ]"
            >Remember me</a-checkbox>
            <a class="login-form-forgot" href>Forgot password</a>
            <a-button type="primary" html-type="submit" class="login-form-button">Log in</a-button>Or
            <a href>register now!</a>
          </a-form-item>
        </a-form>
      </div>
    </div>
  </div>
</template>
<script>
import { mapMutations, mapActions } from 'vuex'
export default {
  name: 'LoginForm',
  beforeCreate () {
    this.form = this.$form.createForm(this, { name: 'normal_login' })
  },
  methods: {
    ...mapMutations([
      'setAccess'
    ]),
    ...mapActions([
      'handleLogin',
      'getUserInfo'
    ]),

    handleSubmit (e) {
      e.preventDefault()
      let vm = this
      this.form.validateFields((err, values) => {
        if (!err) {
          this.handleLogin(values).then(res => {
            debugger
            this.$router.push({
              name: vm.$config.homePage
            })
          })
          console.log('Received values of form: ', values)
        }
      })
    }
  }
}
</script>
<style scoped>
#components-form-demo-normal-login .login-form {
  max-width: 300px;
}
#components-form-demo-normal-login .login-form-forgot {
  float: right;
}
#components-form-demo-normal-login .login-form-button {
  width: 100%;
}
.container {
  display: -ms-flexbox;
  display: flex;
  -ms-flex-direction: column;
  flex-direction: column;
  min-height: 100%;
}
@media (min-width: 768px) {
  .container {
    background-repeat: no-repeat;
    background-position: center 110px;
    background-size: 100%;
    font-size: 18px;
  }
}
.content {
  padding: 32px 0;
  -ms-flex: 1 1 0%;
  flex: 1 1 0%;
}
.main {
  width: 368px;
  margin: 0 auto;
}
@media (min-width: 768px) {
  .content {
    padding: 112px 0 24px;
  }
}
.top {
  text-align: center;
}
.header {
  height: 44px;
  line-height: 44px;
}
.logo {
  height: 28px;
  vertical-align: top;
}
.title {
  font-size: 26px;
  color: rgba(0, 0, 0, 0.85);
  font-family: "Myriad Pro", "Helvetica Neue", Arial, Helvetica, sans-serif;
  font-weight: 400;
  position: relative;
  top: 2px;
}
.desc {
  font-size: 14px;
  color: rgba(0, 0, 0, 0.45);
  margin-top: 12px;
  margin-bottom: 40px;
}
.tenant-title {
  margin-bottom: 24px;
  text-align: center;
}
</style>
