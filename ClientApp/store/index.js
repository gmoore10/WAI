import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'

// STATE
const state = {
    categories: [
        {id: 1, name: "Mortgage", budgeted: 182.56, remaining: 117.44, avgspend: 150.41},
        {id: 2, name: "Auto Fuel", budgeted: 182.56, remaining: 117.44, avgspend: 150.41}
    ]
}

// MUTATIONS
const mutations = {
}

// ACTIONS
const actions = ({
})

// GETTERS
const getters = {
    categories: state => state.categories
}

export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters: getters
});
