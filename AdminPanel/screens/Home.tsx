import { StatusBar } from 'expo-status-bar';
import React, { useState, useLayoutEffect } from 'react';
import { FlatList, StyleSheet, Text, TouchableHighlight, View } from 'react-native';

import { home, colors, screens } from './../resources.json'
import { gStyles } from './../Styles';

export type screensEnum = 'home' | 'users' | 'reports' | 'HCS' | 'user-property'

export type MenuButton = {
    id: string
    name: string
    screen: screensEnum
}

export default function Home({ navigation }: any) {

    const [buttons, setButtons]: [buttons: MenuButton[], setButton: any] = useState(home.buttons.map((current, index) => {
        return (

            {
                id: index.toString(),
                name: current.name,
                screen: (current.screen as screensEnum)
            }
        )
    }));

    /*
    useLayoutEffect(() => {
                        navigation.setOptions({
                            headerTitle: () => (
                                <Header />
                            ),

                        });
    }, [navigation]);
                    */

    const renderButton = ({ item }: { item: MenuButton }) => (
        <TouchableHighlight onPress={() => navigation.navigate(screens[item.screen])} style={styles.button}>
            <Text style={[gStyles.titleText, { color: "#ffffff" }]}>{item.name}</Text>
        </TouchableHighlight>
    )

    return (
        <View>
            <FlatList
                data={buttons}
                renderItem={renderButton}
                keyExtractor={item => item.id}
            />
        </View>

    );
}

const styles = StyleSheet.create({
    button: {
        padding: 5,
        margin: 5,
        backgroundColor: colors.primary,
        alignItems: "center"
    },
    container: {
        flex: 1,
        backgroundColor: colors.background,
        alignItems: 'center',
        justifyContent: 'center',
    },
});
