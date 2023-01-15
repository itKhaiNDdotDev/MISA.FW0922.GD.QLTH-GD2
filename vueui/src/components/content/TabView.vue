<template>
    <router-view @onRequestToast="onShowToast"></router-view>
    <div class="toast-container">
        <MToast v-for="(item, index) in recState" :key="index" :toastType="item.type" :toastMsg="item.msg"/>
    </div>
</template>

<script>
import MToast from "./../base/MToast.vue";

export default {
    name: "TabView",
    components: {
        MToast
    },

    data() {
        return {
            recState: []
        }
    },

    methods: {
        /**
         * Hiển thị toast message tương ứng trong vòng 3s
         * @param {Number} toastType loại toast tương ứng Ebum Status.js
         * @param {String} toastMsg thông điệp tương ứng hiển thị trên content của toast
         * Author: KhaiND (24/12/2022)
         */
        onShowToast(toastType, toastMsg) {
            var state = {
                type: toastType,
                msg: toastMsg
            };
            this.recState.push(state);
            setTimeout(() => {
                this.recState.pop();
            }, 3000);
        }
    },

    // mounted() {
    //     var obj = { type: 3, msg: "abc"};
    //     this.recState.push(obj);
    //     setTimeout(() => {
    //         this.recState.pop();
    //     }, 3000);   
    // },
}
</script>

<style>
.toast-container {
    position: fixed;
    bottom: 8px;
    right: 16px;
    z-index: 10;
}
</style>