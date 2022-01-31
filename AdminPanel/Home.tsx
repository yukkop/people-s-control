import { StatusBar } from 'expo-status-bar';
import React, { useState, useLayoutEffect } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import * as ScreenOrientation from 'expo-screen-orientation';

import { Header } from './Header';

export default function Home({ navigation }: any) {

    useLayoutEffect(() => {
        navigation.setOptions({
            headerTitle: () => (
                <Header />
            ),

        });
    }, [navigation]);

    return (
        <View style={styles.container}>
            <Text>HomePage</Text>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#fff',
        alignItems: 'center',
        justifyContent: 'center',
    },
});
