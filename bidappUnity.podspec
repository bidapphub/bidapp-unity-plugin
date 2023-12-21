Pod::Spec.new do |s|

  s.name         = 'bidappUnity'
  s.version      = '2.1.3'
  s.platform     = :ios, '11.0'
  
  s.summary      = 'bidapp Unity adapter for iOS'
  s.description  = <<-DESC
  bidapp - The perfect solution for boosting your monetization income!
DESC

  s.homepage     = 'https://bidapp.io'
  s.author       = { 'bidapp' => 'support@bidapp.io' }
  s.license      = { :type => 'Copyright', :text => 'Copyright 2023 bidapp. All Rights Reserved.' }
  s.source       = { :http => "https://downloads.bidapp.io/mobile-sdk/ios/2.1.3/bidappSDK-2.1.3.zip", :type => "zip" }
  
  s.swift_versions = '5.0'
  s.swift_version = '5.0'
  s.static_framework = true

  ### UnityAdapter ###
  s.subspec 'UnityAdapter' do |ss|
    ss.requires_arc = true

    ss.source_files = 'plugins/unity/*.{h,mm}'
  
    ss.frameworks = ['Foundation','UIKit']
    ss.weak_frameworks = []
    ss.libraries = []

    ss.pod_target_xcconfig = { 'OTHER_LDFLAGS' => '-ObjC' }
    ss.xcconfig              = {
        'HEADER_SEARCH_PATHS' => [
            '"${PODS_TARGET_SRCROOT}/bidapp"'
        ]}
    ss.dependency 'bidapp/SDK', '2.1.3'
  end
end
