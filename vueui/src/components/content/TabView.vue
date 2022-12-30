<template>
    <router-view></router-view>
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
            recState: [
                // {
                //     type: 1,
                //     msg: "Có lỗi xảy ra"
                // },
                // {
                //     type: 2,
                //     msg: "Hê hê hê"
                // }
            ]
        }
    },

    methods: {
        
    },

    mounted() {
        var obj = { type: 3, msg: "abc"};
        this.recState.push(obj);
            setTimeout(() => {
                this.recState.pop();
            }, 3000);
       
    },
}
</script>

<style>
.toast-container {
    position: fixed;
    bottom: 8px;
    right: 16px;
}
</style>