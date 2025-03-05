namespace Bidapp
{
    public sealed class BidappSDKDelegateIOS : BidappSDKDelegate
    {
        private void onInterstitialDidLoadAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnInterstitialDidLoadAd(identifier, networkId);
        }

        private void onInterstitialDidFailToLoadAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 3);
            string identifier = args[0];
            string networkId = args[1];
            string errorDescription = args[2];

            event_OnInterstitialDidFailToLoadAd(identifier, networkId, errorDescription);
        }

        private void onInterstitialDidDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnInterstitialDidDisplayAd(identifier, networkId);
        }

        private void onInterstitialDidClickAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnInterstitialDidClickAd(identifier, networkId);
        }

        private void onInterstitialDidHideAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnInterstitialDidHideAd(identifier, networkId);
        }

        private void onInterstitialDidFailToDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 3);
            string identifier = args[0];
            string networkId = args[1];
            string errorDescription = args[2];

            event_OnInterstitialDidFailToDisplayAd(identifier, networkId, errorDescription);
        }

        private void onInterstitialDidReceiveRevenue(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 5);
            string identifier = args[0];
            string networkId = args[1];
            string networkName = args[2];
            double revenue = ConvertToDouble(args[3]);
            string precision = args[4];

            event_OnInterstitialDidReceiveRevenue(identifier, networkId, networkName, revenue, precision);
        }

        private void onInterstitialAllNetworksFailedToDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 3);
            string identifier = args[0];

            event_OnInterstitialAllNetworksFailedToDisplayAd(identifier);
        }

        private void onRewardedDidLoadAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnRewardedDidLoadAd(identifier, networkId);
        }

        private void onRewardedDidFailToLoadAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 3);
            string identifier = args[0];
            string networkId = args[1];
            string errorDescription = args[2];

            event_OnRewardedDidFailToLoadAd(identifier, networkId, errorDescription);
        }

        private void onRewardedDidDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnRewardedDidDisplayAd(identifier, networkId);
        }

        private void onRewardedDidClickAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnRewardedDidClickAd(identifier, networkId);
        }

        private void onRewardedDidHideAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnRewardedDidHideAd(identifier, networkId);
        }

        private void onRewardedDidFailToDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 3);
            string identifier = args[0];
            string networkId = args[1];
            string errorDescription = args[2];

            event_OnRewardedDidFailToDisplayAd(identifier, networkId, errorDescription);
        }

        private void onRewardedDidReceiveRevenue(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 5);
            string identifier = args[0];
            string networkId = args[1];
            string networkName = args[2];
            double revenue = ConvertToDouble(args[3]);
            string precision = args[4];

            event_OnRewardedDidReceiveRevenue(identifier, networkId, networkName, revenue, precision);
        }

        private void onRewardedAllNetworksFailedToDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 1);
            string identifier = args[0];

            event_OnRewardedAllNetworksFailedToDisplayAd(identifier);
        }

        private void onUserDidReceiveReward(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 1);
            string identifier = args[0];

            event_OnUserDidReceiveReward(identifier);
        }

        private void onBannerDidDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnBannerDidDisplayAd(identifier, networkId);
        }

        private void onBannerFailedToDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];
            string errorDescription = args[2];

            event_OnBannerFailedToDisplayAd(identifier,networkId,errorDescription);
        }

        private void onBannerClicked(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 2);
            string identifier = args[0];
            string networkId = args[1];

            event_OnBannerClicked(identifier, networkId);
        }

        private void onBannerDidReceiveRevenue(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 5);
            string identifier = args[0];
            string networkId = args[1];
            string networkName = args[2];
            double revenue = ConvertToDouble(args[3]);
            string precision = args[4];

            event_OnBannerDidReceiveRevenue(identifier, networkId, networkName, revenue, precision);
        }

        private void onBannerAllNetworksFailedToDisplayAd(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 1);
            string identifier = args[0];

            event_OnBannerAllNetworksFailedToDisplayAd(identifier);
        }

        private void onEvent(string packedArguments)
        {
            string[] args = UnpackArgs(packedArguments, 1000);

            event_OnEvent(args);
        }

        private double ConvertToDouble(string Value)
        {
            if (Value == null)
            {
                return 0;
            }
            else
            {
                double OutVal;
                double.TryParse(Value, out OutVal);

                if (double.IsNaN(OutVal) || 
                    double.IsInfinity(OutVal))
                {
                    return 0;
                }

                return OutVal;
            }
        }

        private string[] UnpackArgs(string s, uint count)
        {
            if (0 == count)
            {
                return null;
            }

            string[] args = new string[count];

            int idx;
            for ( idx = 0; idx < count; idx++ )
            {
                args[idx] = "";
            }

            int j = 0;
            while (0 != s.Length)
            {
                int i = s.IndexOf('#');
                if (-1 == i)
                {
                    break;
                }

                int length = 0;
                if (!int.TryParse(s.Substring(0, i), out length) ||
                    length < 0)
                {
                    //Console.WriteLine("Error while calculating string length");
                    break;
                }

                //Console.WriteLine("String length: " + length);
                int endOfString = i + 1 + length;

                if (endOfString > s.Length)
                {
                    //Console.WriteLine("Error while deserializing");

                    break;
                }

                string str = s.Substring(i+1, length);

                args[j] = str;
                ++j;

                if (j == count)
                {
                    break;
                }

                //Console.WriteLine("String: \"" + str + "\"");

                if ((endOfString+1) >= s.Length)
                {
                    //Console.WriteLine("End of string reached");

                    break;
                }

                s = s.Substring(endOfString + 1);
            }

            if (j < count)
            {
                //Console.WriteLine("Warning! not all arguments were extracted");
            }

            return args;
        }
    }
}
