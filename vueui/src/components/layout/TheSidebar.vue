<template>
    <div class="sidebar" :class="{sidebarHidden:isHiddenSidebar}">
            <div class="sidebar__head">
                <div class="sidebar__head--left">
                   <div class="m-logo m-icon icon-logo-khoanthu"></div>
                   <div class="m-title">{{appTitle}}</div>
                </div>
                <div class="sidebar__head--right m-icon icon-sidebar" @click="toggleSidebar"></div>
            </div>

            <div class="sidebar__menu">
                <router-link to="/test" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-tongquan"></div>
                    <div class="menu-item--text">{{menuText.Overview.menu}}</div>
                </router-link>
                <router-link to="/exemption" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-kehoachthu"></div>
                    <div class="menu-item--text">{{menuText.FeePlan.menu}}</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-quanlythu"></div>
                    <div class="menu-item--text">{{menuText.FeeManage.menu}}</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-hoadon"></div>
                    <div class="menu-item--text">{{menuText.InvoiceManage.menu}}</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-sothu"></div>
                    <div class="menu-item--text">{{menuText.FeeLedger.menu}}</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-baocao"></div>
                    <div class="menu-item--text">{{menuText.Report.menu}}</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-payment"></div>
                    <div class="menu-item--text">{{menuText.OnlinePayment.menu}}</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-hethong"></div>
                    <div class="menu-item--text">{{menuText.System.menu}}</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-daotaoemis" style="background-size: auto;"></div>
                    <div class="menu-item--text">{{menuText.EMISTraining.menu}}</div>
                </router-link>
            </div>
        </div>
</template>

<script>
import LayoutResources from "./../../utils/resources/layout"

export default {
    name: 'TheSidebar',

    data() {
        return {
            isHiddenSidebar: false,
            appTitle: LayoutResources.AppName.Fee,
            menuText: LayoutResources.Tab
        }
    },

    methods: {
        toggleSidebar() {
            this.isHiddenSidebar = !this.isHiddenSidebar;
        }
    },
}
</script>

<style>
@import url(../../styles/layout/sidebar.css);
</style>