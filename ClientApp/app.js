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
import { KendoComboBox, KendoDropdownsInstaller } from '@progress/kendo-dropdowns-vue-wrapper'
import { Chart, ChartSeriesItem, StockChart, Sparkline, SparklineSeriesItem, ChartInstaller } from '@progress/kendo-charts-vue-wrapper'
import BudgetCategoryDropDown from './components/interface/budget-category-dropdown'

Vue.use(KendoDateinputsInstaller)
Vue.use(KendoGridInstaller)
Vue.use(KendoDataSourceInstaller)
Vue.use(KendoDropdownsInstaller)
Vue.use(ChartInstaller)

Vue.use(BudgetCategoryDropDown)

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
        KendoDataSource,
        KendoComboBox,
        Chart,
        BudgetCategoryDropDown
    }
})

export {
    app,
    router,
    store
}