<template>
    <div class="m-dropdown m-combobox">
        <button class="m-icon icon-28 icon-down"></button>
        <input type="text" class="m-input" :class="{errorInput:errorState.isError}"/>

        <div class="combobox__option">
            
            <table>
                <thead>
                    <tr>
                        <th>Col1</th>
                        <th>Col2</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Val1</td>
                        <td>Val2</td>
                    </tr>
                    <tr>
                        <td>Val1</td>
                        <td>Val2</td>
                    </tr>
                    <tr>
                        <td>Val1</td>
                        <td>Val2</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
export default {
    name: "MCombobox",

    props: ["label", "isRequired", "errorState"], //errorState: {isError: Boolean, message: String}

    data() {
      return {
        isShowOption: false,
        opt: {
          head: [
            "Họ tên",
            "Ngày sinh",
            "Lớp"
          ],
          data: [
            {
              name: "KhaiND",
              date: "11/11/2111",
              class: "2/2"
            },
            {
              name: "KhaiND",
              date: "11/11/2111",
              class: "2/2"
            }
          ]
        }
      }
    },
}
</script>

<style scoped>
.m-combobox {
    background-color: aqua;
    position: relative;
}

.combobox__option {
    border-radius: 4px;
    background-color: aqua;
    position: absolute;
    top: calc(100% + 1px);
}

.combobox__option table {
    position: relative;
    border-radius: 4px;
    border: none;
    padding: 0px;
    margin: 0px;
    background-color: inherit;
}

.combobox__option table th, .combobox__option table td, .combobox__option table tr {
    border: none;
    background-color: inherit;
}
</style>