<template>
    <div id="app" class="container-fluid">
        <div class="row">
            <div class="" style="width: 100%; height: 75px;">
                <nav-menu params="route: route"></nav-menu>
            </div>
            <div class="col-sm-9">
                <router-view></router-view>
            </div>
        </div>

    </div>

</template>

<script>
import Vue from 'vue'
import NavMenu from './nav-menu'
import BudgetCategories from './budget-categories'
import BudgetTransactions from './budget-transactions'
import ReportsAnnual from './reports-annual'
import ReportsCurrentMonth from './reports-currentmonth'

Vue.component('nav-menu', NavMenu);
Vue.component('budget-categories', BudgetCategories)
Vue.component('budget-transactions', BudgetTransactions)
Vue.component('reports-annual', ReportsAnnual)
Vue.component('reports-currentmonth', ReportsCurrentMonth)

export default {
    data() {
        return {
        }
    }
}
</script>

<style>
</style>