<template>
    <div class="sidebar">
            <div class="sidebar__head">
                <div class="sidebar__head--left">
                   <div class="m-logo m-icon icon-logo-khoanthu"></div>
                   <div class="m-title">Khoản thu</div>
                </div>
                <div class="sidebar__head--right m-icon icon-sidebar"></div>
            </div>

            <div class="sidebar__menu">
                <router-link to="/test" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-tongquan"></div>
                    <div class="menu-item--text">Tổng Quan</div>
                </router-link>
                <router-link to="/exemption" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-kehoachthu"></div>
                    <div class="menu-item--text">Lập kế hoạch thu</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-quanlythu"></div>
                    <div class="menu-item--text">Quản lý thu</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-hoadon"></div>
                    <div class="menu-item--text">Quản lý hóa đơn</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-sothu"></div>
                    <div class="menu-item--text">Số phải thu, phải trả</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-baocao"></div>
                    <div class="menu-item--text">Báo cáo</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-payment"></div>
                    <div class="menu-item--text">Thanh toán online</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-hethong"></div>
                    <div class="menu-item--text">Hệ thống</div>
                </router-link>
                <router-link to="/" class="menu-item">
                    <div class="menu-item--icon m-icon icon-32 icon-daotaoemis"></div>
                    <div class="menu-item--text">Đào tạo MISA EMIS</div>
                </router-link>
            </div>
        </div>
</template>

<script>
export default {
    name: 'TheSidebar',
}
</script>

<style>
@import url(../../styles/layout/sidebar.css);
</style>