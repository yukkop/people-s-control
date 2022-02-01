import { StatusBar } from 'expo-status-bar';
import React, { useState, useLayoutEffect } from 'react';
import { FlatList, StyleSheet, Text, TouchableHighlight, View } from 'react-native';

import { home, colors, screens } from './../resources.json'
import { gStyles } from './../Styles';
import { api } from './../API'
import { User } from './Users';

export type ScreensEnum = keyof typeof screens

export type MenuButton = {
    id: string
    name: string
    screen: ScreensEnum
}

export default function Home({ navigation }: any) {
    api<User>("https://194.28.61.185:44373/api/user/Authorization", 'GET', 'admin', 'B2ling54B2ling3rPL292')
    const [buttons, setButtons]: [buttons: MenuButton[], setButton: any] = useState(home.buttons.map((current, index) => {
        return (

            {
                id: index.toString(),
                name: current.name,
                screen: (current.screen as ScreensEnum)
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
        <TouchableHighlight onPress={() => navigation.navigate(screens[item.screen].path)} style={styles.button}>
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
