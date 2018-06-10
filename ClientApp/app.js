import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'

import '@progress/kendo-theme-bootstrap/dist/all.css'
import '@progress/kendo-ui'
import { KendoDatePicker, KendoDateinputsInstaller } from '@progress/kendo-dateinputs-vue-wrapper'
import { KendoGridColumn, KendoGrid, KendoGridInstaller } from '@progress/kendo-grid-vue-wrapper'
import { KendoDataSource, KendoDataSourceInstaller } from '@progress/kendo-datasource-vue-wrapper'

Vue.use(KendoDateinputsInstaller)
Vue.use(KendoGridInstaller)
Vue.use(KendoDataSourceInstaller)

Vue.prototype.$http = axios;

sync(store, router)

const app = new Vue({
    store,
    router,
    ...App,
    components: {
        KendoDatePicker,
        KendoGrid,
        KendoGridColumn,
        KendoDataSource
    }
})

export {
    app,
    router,
    store
}