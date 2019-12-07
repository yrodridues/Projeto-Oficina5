<template>
  <v-toolbar
    id="core-toolbar"
    flat
    prominent
    style="background: #B22222;">
    <div class="v-toolbar-title">
      <v-toolbar-title
        class="white--text"
        color="cyan lighten-1">
        <v-btn
          v-if="responsive"
          class="default v-btn--simple"
          dark
          icon
          @click.stop="onClickBtn">
          <v-icon>mdi-view-list</v-icon>
        </v-btn>
        {{ title }}
      </v-toolbar-title>
    </div>

    <v-spacer />
    <v-toolbar-items>
      <v-flex
        align-center
        layout
        py-2>
        <router-link
          v-ripple
          class="toolbar-items"
          to="/login">
          <v-icon color="tertiary">mdi-logout</v-icon>
        </router-link>
      </v-flex>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>

import {
  mapMutations
} from 'vuex'

export default {
  data: () => ({
    title: null,
    responsive: false,
    responsiveInput: false
  }),
  watch: {
    '$route' (val) {
      this.title = val.name
    }
  },
  mounted () {
    this.onResponsiveInverted()
    window.addEventListener('resize', this.onResponsiveInverted)
  },
  beforeDestroy () {
    window.removeEventListener('resize', this.onResponsiveInverted)
  },

  methods: {
    ...mapMutations('app', ['setDrawer', 'toggleDrawer']),
    onClickBtn () {
      this.setDrawer(!this.$store.state.app.drawer)
    },
    onClick () {
      //
    },
    onResponsiveInverted () {
      if (window.innerWidth < 991) {
        this.responsive = true
        this.responsiveInput = false
      } else {
        this.responsive = false
        this.responsiveInput = true
      }
    }
  }
}
</script>

<style>
  #core-toolbar a {
    text-decoration: none;
  }
  .v-toolbar{
    margin-top: 0px;
    margin-bottom: 0px !important;
  }
  .v-toolbar__content{
    padding-top: 0px !important;
    padding-bottom: 0px !important;
  }
</style>
