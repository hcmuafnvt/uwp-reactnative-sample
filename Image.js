import React, { PropTypes } from 'react'
import { View, requireNativeComponent } from 'react-native'
import resolveAssetSource from 'react-native/Libraries/Image/resolveAssetSource'

export default class ImageComponent extends React.Component {

    static propTypes = {
        src: PropTypes.object,
      ...View.propTypes
    }

    render () {
        const source = this.props.source || {};

        let uri = source.uri
    
        const nativeProps = {
        ...this.props,
            src: {uri}
        }

        return (
            <RCTImageGif {...nativeProps} />
        )
    }
}

var RCTImageGif = requireNativeComponent('ImageComponent', ImageComponent)