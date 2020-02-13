import Vue from 'vue'
import App from './App'
import store from './store'
import router from './router'
import config from './config/index'
import './index.less'
// abp import--start
import Ajax from './lib/ajax'
import Util from './lib/util'
import SignalRAspNetCoreHelper from './lib/SignalRAspNetCoreHelper'
// abp --end

import VueTypedJs from 'vue-typed-js'
import {
  Affix,
  Anchor,
  AutoComplete,
  Alert,
  Avatar,
  BackTop,
  Badge,
  Breadcrumb,
  Button,
  Calendar,
  Card,
  Collapse,
  Carousel,
  Cascader,
  Checkbox,
  Col,
  DatePicker,
  Divider,
  Dropdown,
  Form,
  Icon,
  Input,
  InputNumber,
  Layout,
  List,
  LocaleProvider,
  message,
  Menu,
  Modal,
  notification,
  Pagination,
  Popconfirm,
  Popover,
  Progress,
  Radio,
  Rate,
  Row,
  Select,
  Slider,
  Spin,
  Statistic,
  Steps,
  Switch,
  Table,
  Transfer,
  Tree,
  TreeSelect,
  Tabs,
  Tag,
  TimePicker,
  Timeline,
  Tooltip,
  // Mention,
  Upload,
  // version,
  Drawer,
  Skeleton,
  Comment,
  ConfigProvider,
  Empty,
  Base
} from 'ant-design-vue'
Vue.config.productionTip = false

Vue.prototype.$message = message
Vue.prototype.$notification = notification
Vue.prototype.$info = Modal.info
Vue.prototype.$success = Modal.success
Vue.prototype.$error = Modal.error
Vue.prototype.$warning = Modal.warning
Vue.prototype.$confirm = Modal.confirm
Vue.prototype.$destroyAll = Modal.destroyAll

/* v1.1.3+ registration methods */
Vue.use(Base)
Vue.use(Affix)
Vue.use(Anchor)
Vue.use(AutoComplete)
Vue.use(Alert)
Vue.use(Avatar)
Vue.use(BackTop)
Vue.use(Badge)
Vue.use(Breadcrumb)
Vue.use(Button)
Vue.use(Calendar)
Vue.use(Card)
Vue.use(Collapse)
Vue.use(Carousel)
Vue.use(Cascader)
Vue.use(Checkbox)
Vue.use(Col)
Vue.use(DatePicker)
Vue.use(Divider)
Vue.use(Drawer)
Vue.use(Dropdown)
Vue.use(Form)
Vue.use(Icon)
Vue.use(Input)
Vue.use(InputNumber)
Vue.use(Layout)
Vue.use(List)
Vue.use(LocaleProvider)
Vue.use(Menu)
Vue.use(Modal)
Vue.use(Pagination)
Vue.use(Popconfirm)
Vue.use(Popover)
Vue.use(Progress)
Vue.use(Radio)
Vue.use(Rate)
Vue.use(Row)
Vue.use(Select)
Vue.use(Slider)
Vue.use(Spin)
Vue.use(Statistic)
Vue.use(Steps)
Vue.use(Switch)
Vue.use(Table)
Vue.use(Transfer)
Vue.use(Tree)
Vue.use(TreeSelect)
Vue.use(Tabs)
Vue.use(Tag)
Vue.use(TimePicker)
Vue.use(Timeline)
Vue.use(Tooltip)
Vue.use(Upload)
Vue.use(Skeleton)
Vue.use(Comment)
Vue.use(ConfigProvider)
Vue.use(Empty)

Vue.use(VueTypedJs)
/**
 * @description 全局注册应用配置
 */
Vue.prototype.$config = config
if (config.useAbp) {
  // abp logic start
  // 国际化语言设置
  // eslint-disable-next-line no-undef
  if (!abp.utils.getCookieValue('Abp.Localization.CultureName')) {
    let language = navigator.language
    // eslint-disable-next-line no-undef
    abp.utils.setCookieValue('Abp.Localization.CultureName', language, new Date(new Date().getTime() + 5 * 365 * 86400000), abp.appPath)
  }
  /* eslint-disable no-new */
  Ajax.get('/AbpUserConfiguration/GetAll').then(data => {
    Util.abp = Util.extend(true, Util.abp, data.data.result)
    new Vue({
      el: '#app',
      router,
      store,
      render: h => h(App),
      async mounted () {
        await this.$store.dispatch('session/init')
        if (!!this.$store.state.session.user && this.$store.state.session.application.features['SignalR']) {
          if (this.$store.state.session.application.features['SignalR.AspNetCore']) {
            SignalRAspNetCoreHelper.initSignalR()
          }
        }
      }
    })
  })
  // abp logic end
} else {
  /* eslint-disable no-new */
  new Vue({
    el: '#app',
    store,
    router,
    components: { App },
    template: '<App/>'
  })
}
