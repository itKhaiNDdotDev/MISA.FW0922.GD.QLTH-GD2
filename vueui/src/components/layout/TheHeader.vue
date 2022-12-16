<template>
    <div class="header">
        <div class="header--left header-title">{{headerText.PageTitle}}</div>

        <div class="header--right">
            <div class="m-input nav-home-app border-radius">
                <div class="m-icon icon-home"></div>
                {{headerText.SchoolName}}
            </div>
            <MDropdown value="2021 - 2022" style="width: 124px" :numberColumn="1"/>
            <div class="m-button text-button btn-guide">{{buttonText.Guide}}</div>
           
            <div class="hor-line"></div>
            <div class="m-icon icon-32 icon-help-green" :title="tooltip.Help"></div>
            <div class="m-icon icon-32 icon-notification" :title="tooltip.Noti">
                <div class="noti--quantity">{{countNotification}}</div>
            </div>

            <div class="m-account" :title="tooltip.Account">
                <img src="../../assets/Images/KhaiND.png" alt="" class="acc-avatar">
                <div class="acc-name">{{headerText.AccountName}}</div>
                <div class="m-icon icon-24 icon-down"></div>
            </div>          
        </div>
    </div>
</template>

<script>
import Resources from "./../../utils/resources/common"
import LayoutResources from "./../../utils/resources/layout";
// import MInput from "./../base/MInput.vue";
import MDropdown from "./../base/MDropdown.vue";

export default {
  name: "TheHeader",
  components: {
    // MInput,
    MDropdown
  },

  data() {
    return {
        headerText: LayoutResources.Hader,
        buttonText: Resources.Button,
        tooltip: Resources.ToolTip,
        countNotification: "9+"
    }
  },
};
</script>

<style>
@import url(../../styles/layout/header.css);

.btn-guide {
    background-color: #00925340;
    color: var(--main-green);
    margin: 0px !important;
}

.nav-home-app {
    width: fit-content;
    display: flex;
    align-items: center;
    margin: 0px 16px;
    padding-left: 0px !important;
    cursor: pointer;
}

.nav-home-app .icon-home {
    background-color: var(--main-green);
    width: 30px;
    height: 30px;
    margin-right: 12px;
    border-radius: 4px 0px 0px 4px;
}
</style>