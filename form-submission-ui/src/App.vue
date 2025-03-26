<template>
    <nav>
        <router-link to="/">Submit Form</router-link> |
        <router-link to="/submissions">View Submissions</router-link>
    </nav>
    <router-view />
</template>

<style>
    nav {
        padding: 10px;
        background: #3498db;
        color: white;
        text-align: center;
    }

        nav a {
            color: white;
            margin: 0 15px;
            text-decoration: none;
            font-size: 18px;
        }
</style>
