import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'

import { KendoDatePicker, KendoDateinputsInstaller } from '@progress/kendo-dateinputs-vue-wrapper'
import '@progress/kendo-theme-bootstrap/dist/all.css'
import '@progress/kendo-ui'

Vue.use(KendoDateinputsInstaller)

Vue.prototype.$http = axios;

sync(store, router)

const app = new Vue({
    store,
    router,
    ...App,
    components: {
        KendoDatePicker
    }
})

export {
    app,
    router,
    store
}