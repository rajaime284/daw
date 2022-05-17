<template>
  <div id="app">
    <Head />

    <div class="container">
        <main role="main" class="pb-3">
            <router-view/>
        </main>
    </div>

    <Foot/>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Head from '@/components/layout/Head.vue'; 
import Foot from '@/components/layout/Foot.vue';

@Component({
  components: {
    Foot,
    Head
  },
})

export default class App extends Vue {}
</script>
