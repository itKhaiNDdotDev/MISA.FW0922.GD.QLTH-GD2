<template>
    <div class="content__navtab">
        <div class="m-tab">{{tabText.Process}}</div>
        <div class="m-tab">{{tabText.FeeList}}</div>
        <div class="m-tab">{{tabText.RegisterStage}}</div>
        <div class="m-tab">{{tabText.Register}}</div>
        <div class="m-tab tab--focus">{{tabText.ExemptionList}}</div>
        <div class="m-tab">{{tabText.PricePolicy}}</div>
    </div>
</template>

<script>
import LayoutResources from "./../../utils/resources/layout"

export default {
    name: "TabNavbar",

    data() {
        return {
            tabText: LayoutResources.Tab.FeePlan
        }
    },
}
</script>

<style scoped>
@import url(../../styles/component/tab.css);

.content__navtab {
    display: flex;
}
</style>