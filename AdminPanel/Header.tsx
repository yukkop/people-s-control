import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, ScrollView, FlatList } from 'react-native';
import * as ScreenOrientation from 'expo-screen-orientation';

import resources from './resources.json';
import { useState } from 'react';

export type tab = {
    id: string,
    name: string,
    description: string,
    request: string,
    items: any,
    body: any,
    isOpen: boolean
}

export function Header() {
    const controllers = resources.controllers;

    const [controller, setController] = useState(controllers[0])
    const [tabs, setTabs] = useState(controller.tabs.map((current, index) => {
        return (
            {
                id: index.toString(),
                name: current.name,
                description: current.description,
                request: current.request,
                items: current.items,
                body: current.body,
                isOpen: false
            }
        )
    }));

    const renderTab = ({ item }: { item: tab }) => (
        <View style={styles.tab}>
            <Text>{item.name}</Text>
        </View>
    )

    ScreenOrientation.lockAsync(ScreenOrientation.OrientationLock.LANDSCAPE);
    return (
        <FlatList
            data={tabs}
            renderItem={renderTab}
            keyExtractor={item => item.id}
            horizontal={true} />
    );
}

export function HeaderLeft() {
    ScreenOrientation.lockAsync(ScreenOrientation.OrientationLock.LANDSCAPE);
    return (
        <View></View>
    );
}

const styles = StyleSheet.create({
    tab: {
        padding: 5,
        margin: 5,
        backgroundColor: resources.colors.primar
    },
    container: {
        flex: 1,
        backgroundColor: resources.colors.background,
        alignItems: 'center',
        justifyContent: 'center',
    },
});
