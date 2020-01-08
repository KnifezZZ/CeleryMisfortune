<template>
  <div>
    <login-form v-if="!$config.useTenant" />
    <login-tenant-form v-else />
  </div>
</template>

<script>
import LoginForm from '@/components/login/login-default'
import LoginTenantForm from '@/components/login/login-tenant'
export default {
  beforeCreate () {
    this.form = this.$form.createForm(this, { name: 'normal_login' })
  },
  methods: {
  },
  components: {
    LoginForm,
    LoginTenantForm
  }

}
</script>
<style>
#components-form-demo-normal-login .login-form {
  max-width: 300px;
}
#components-form-demo-normal-login .login-form-forgot {
  float: right;
}
#components-form-demo-normal-login .login-form-button {
  width: 100%;
}
</style>
