﻿<template>
    <div class="">
        <div class="navbar navbar-inverse">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" v-on:click="toggleCollapsed">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                <img src="/dist/logo.png" style="width: 75px; height: 75px;" />
            </div>
            <transition name="slide">
                <div class="navbar-collapse collapse in" v-show="!collapsed">
                    <ul class="nav navbar-nav">
                        <li v-for="route in routes" v-bind:key="route.path">
                            <!-- TODO: highlight active link -->
                            <router-link :to="route.path">
                                {{ route.display }}
                            </router-link>
                        </li>
                    </ul>
                </div>
            </transition>
        </div>
    </div>
</template>

<script>
import { routes } from '../routes'

export default {
    data() {
        return {
            routes,
            collapsed : true
        }
    },
    methods: {
        toggleCollapsed: function(event){
            this.collapsed = !this.collapsed;
        }
    }
}
</script>

<style>
.slide-enter-active, .slide-leave-active {
  transition: max-height .35s
}
.slide-enter, .slide-leave-to {
  max-height: 0px;
}

.slide-enter-to, .slide-leave {
  max-height: 20em;
}
</style>