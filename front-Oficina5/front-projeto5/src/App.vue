<template>
  <v-app>

    <core-toolbar v-if="$route.path!=='/login'"/>

    <core-drawer v-if="$route.path!=='/login'"/>

    <core-view />
  </v-app>
</template>

<script>
import { mapState, mapActions } from 'vuex'
/* import SimplifiedMultipleFiltersTable from '@/components/SimplifiedMultipleFiltersTable' */
export default {
  name: 'App',
  components: {
    /* SimplifiedMultipleFiltersTable */
  },
  computed: {
    ...mapState({
      alert: state => state.alert
    })
  },
  methods: {
    ...mapActions({
      clearAlert: 'alert/clear'
    })
  },
  // eslint-disable-next-line vue/order-in-components
  watch: {
    $route (to, from) {
      // clear alert on location change
      this.clearAlert()
    }
  }
}
</script>

<style lang="scss">
@import '@/styles/index.scss';
#core-view {
 padding-bottom: 0px !important;
}
html {
 background: #EEEEEE;
}
.posicionamentoExterno{
 text-align: center;
 width: 100%;
}
.posicionamentoInterno{
 font-size: 16px!important;
 display: inline-block
}
.v-datatable thead th.column.sortable i {
 vertical-align: unset;
}

table.v-table thead th{
 font-size: 16px;
}
table.v-table tbody td{
 font-size: 16px;
}

table.v-table tbody td:first-child, table.v-table tbody td:not(:first-child), table.v-table tbody th:first-child, table.v-table tbody th:not(:first-child), table.v-table thead td:first-child, table.v-table thead td:not(:first-child), table.v-table thead th:first-child, table.v-table thead th:not(:first-child) {
 padding: 0px 10px 0px !important;
}

.v-card .v-offset .v-card--material__header.v-card{
 color: white !important;
}

.theme--light.v-input:not(.v-input--is-disabled) input, .theme--light.v-input:not(.v-input--is-disabled) textarea{
 font-size: 16px;
}
.v-navigation-drawer .v-list .v-divider {
   border-color: rgba(180, 180, 180, 0.3);
   margin: -1px auto 0px;
   width: calc(100% - 30px);
}

.v-btn--floating, .v-btn--icon:before{
     border-radius: 50% !important;
}
.v-pagination__more{
 display: none !important;
}

#app-drawer {
 .v-list__tile {
   border-radius: 4px;

   &--buy {
     margin-top: auto;
     margin-bottom: 17px;
   }
 }

 .v-image__image--contain {
   top: 9px;
   height: 60%;
 }

 div.v-responsive.v-image > div.v-responsive__content {
   overflow-y: auto;
 }
}

.logo .v-list__tile--avatar {
 padding-bottom: 0px !important;
}

.v-navigation-drawer .v-list .v-avatar {
 background-color: white;
}

.v-list-item {
 margin: 5px 15px 5px !important;
}

.v-list__group__header {
 margin-left: 20px !important;
 padding-top: 10px !important;
 padding-bottom: 10px !important;
}

.v-navigation-drawer .v-list .v-list-item .v-list__tile.v-list__tile--active.primary{
 color: white;
}
.v-alert.v-alert {
 border-radius: 30px !important;
}
.caixaLogin {
 margin-top: 100px;
}
</style>
