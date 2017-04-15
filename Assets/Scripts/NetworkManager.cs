using UnityEngine;
using System.Collections;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.CognitoSync;

public class NetworkManager : MonoBehaviour {

    private const string CognitoIdentityPoolId = "us-west-2:a46aac36-2a1c-45bd-99ec-8f4b6f356712";
    private const string MobileAnaylticsAppId = "";

    // Needed only when building for Android
    private const string AndroidPlatformApplicationArn = "";
    private const string GoogleConsoleProjectId = "";

    // Needed only when building for iOS
    private const string IOSPlatformApplicationArn = null;

    private const string NewMatchLambdaFunctionName = "NewChessMatch";
    private const string PlayersDatasetName = "KnownPlayers";
    private const string MatchesDatasetName = "Matches";
    private const string FriendIdPropertyName = "friendId";
    private const string SelfIsWhitePRopertyName = "selfIsWhite";
    private const string ForsythEdwardsNotationPropertyName = "fen";
    private const string AlgebraicNotationPropertyName = "algNot";
    private const string RequesterIdPropertyName = "requesterId";
    private const string OpponentIdPropertyName = "opponentId";
    private const string WhitePlayerDynamoDBIndexKey = "WhitePlayerId-index";
    private const string BlackPlayerDynamoDBIndexKey = "BlackPlayerId-index";

    // By default, we use the Region Endpoint specified in the
    // AWSSDK/src/Core/Resource/awsconfig.xml file. If you are using the same region for all of
    // your services, just change the region value in awsconfig.xml. Otherwise, you can
    // replace the null values below with the correct region endpoints,
    // i.e. RegionEndpoint.USEast1.
    private static readonly RegionEndpoint _cognitoRegion = null;
    private static readonly RegionEndpoint _mobileAnalyticsRegion = null;
    private static readonly RegionEndpoint _dynamoDBRegion = null;
    private static readonly RegionEndpoint _lambdaRegion = null;
    private static readonly RegionEndpoint _snsRegion = null;
    private RegionEndpoint CognitoRegion { get { return _cognitoRegion != null ? _cognitoRegion : AWSConfigs.RegionEndpoint; } }
    private RegionEndpoint MobileAnalyticsRegion { get { return _mobileAnalyticsRegion != null ? _mobileAnalyticsRegion : AWSConfigs.RegionEndpoint; } }
    private RegionEndpoint DynamoDBRegion { get { return _dynamoDBRegion != null ? _dynamoDBRegion : AWSConfigs.RegionEndpoint; } }
    private RegionEndpoint LambdaRegion { get { return _lambdaRegion != null ? _lambdaRegion : AWSConfigs.RegionEndpoint; } }
    private RegionEndpoint SNSRegion { get { return _snsRegion != null ? _snsRegion : AWSConfigs.RegionEndpoint; } }


    private CognitoAWSCredentials _credentials;

    private CognitoAWSCredentials Credentials
    {
        get
        {
            if (_credentials == null)
                _credentials = new CognitoAWSCredentials(CognitoIdentityPoolId, CognitoRegion);
            return _credentials;
        }
    }

}