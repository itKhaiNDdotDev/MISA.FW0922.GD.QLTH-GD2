<template>
    <div class="content">
        <TabNavbar/>
        <TabView/>
    </div>
</template>

<script>
import TabNavbar from "./../content/TabNavbar.vue";
import TabView from "./../content/TabView.vue"

export default {
    name: 'TheContent',
    components: {
        TabNavbar,
        TabView
    }
}
</script>

<style>
@import url(../../styles/layout/content.css);
</style>